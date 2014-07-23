using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace RunningAhead2Kml
{
    class RunningAheadFileProcessing
    {
        private XDocument initialTranformedXml;// = new XDocument();
        private List<Course> courses;

        //Here's what the program should ideally do:
        // 1) Perform initial transformation of the log xml to a temporary Xml file
        // 2) Generate lists of all the workouts and what courses were used and whether they're running or biking, etc
        // 3) Apply any filters to the output log file to only show running and/or biking or style them differently
        // 4) Edit the Xml file with new colors, styles, etc because the XML functions won't work if the "XDocument" is a KML file
        // 5) Perform a final transformation from the Xml to an output Kml document


        internal void ImportXmlLogFile(string logXmlFilePath)
        {
            //Convert local file to in-memory XDocument
            XDocument logFileXml = CreateXDocumentFromFilePath(logXmlFilePath);
            
            //Save file to local directory first - the MVP just to get something started
            //XDocument basicOutputKml = TransformFromResourcesXslt(logXmlFilePath);
            //outputKml = TransformFromLocalXslt(logXmlFilePath); //alternate method, old
            XDocument basicOutputKml = TransformXDocumentWithResourcesXslt(logFileXml, "RA-KML-CourseCollections.xslt");
            
            //save the Kml to a file...
            using (var writer = new XmlTextWriter("log_courses.kml", new UTF8Encoding()))
            {
                writer.Formatting = Formatting.Indented;
                basicOutputKml.Save(writer);
            }

            // 1) initial xsl transformation to XDocument that can be edited by next steps
            initialTranformedXml = TransformXDocumentWithResourcesXslt(logFileXml, "InitialRAxml_transform.xslt");
        }

        internal List<string> IdentifyUniqueWorkoutCombos(string logXmlFilePath)
        {
            // 2) Convert all workouts to a list...
            List<Workout> workouts = new List<Workout>();
            CreateListOfWorkoutsFromLog(logXmlFilePath, workouts);

            //...and find all unique workout type combos per course (i.e. run,  bike,run,  bike,run,walk, etc.)
            List<string> allWorkoutCombos = new List<string>();
            FindAllUniqueWorkoutTypeCombos(initialTranformedXml, workouts, allWorkoutCombos);

            //return list of all workout types to the UI
            return allWorkoutCombos;
        }

        private static void CreateListOfWorkoutsFromLog(string logXmlFilePath, List<Workout> workouts)
        {
            XDocument workoutsXml = XDocument.Load(logXmlFilePath);
            foreach (XElement workoutEvent in workoutsXml.XPathSelectElements("//EventCollection/Event").ToList())
            {
                Workout workout = new Workout();
                workout.type = workoutEvent.Attribute("typeName").Value;
                string dateTest = workoutEvent.Attribute("time").Value;
                DateTime time;
                DateTime.TryParse(workoutEvent.Attribute("time").Value, out time);
                workout.time = time;

                //XmlNode node = workoutEvent.Attributes["name"];
                if (workoutEvent.XPathSelectElement("Route") != null)
                {
                    //exists!
                    workout.courseName = workoutEvent.XPathSelectElement("Route").Value;
                    workout.courseId = workoutEvent.XPathSelectElement("Route").Attribute("id").Value;
                }
                else
                {
                    //doesn't exist
                    workout.courseName = "route map not available";
                }

                workouts.Add(workout);
            }
        }

        private static void FindAllUniqueWorkoutTypeCombos(XDocument initialTranformedXml, List<Workout> workouts, List<string> allWorkoutCombos)
        {
            foreach (XElement placemark in GetPlacemarkNodes(initialTranformedXml))
            {
                string courseIdToFind = placemark.XPathSelectElement("ExtendedData/Data[@name = 'courseId']/value").Value;
                string workoutCombination = GetWorkoutCombinationStringFromCourseId(workouts, courseIdToFind);

                placemark.XPathSelectElement("ExtendedData/Data[@name = 'workoutTypes']/value").Value = workoutCombination;

                if (!allWorkoutCombos.Contains(workoutCombination))
                {
                    allWorkoutCombos.Add(workoutCombination);
                }

                placemark.XPathSelectElement("styleUrl").Value = "style" + allWorkoutCombos.IndexOf(workoutCombination);
            }
        }

        private static string GetWorkoutCombinationStringFromCourseId(List<Workout> workouts, string courseIdToFind)
        {
            List<Workout> filteredWorkouts = workouts.FindAll(w => w.courseId == courseIdToFind).ToList();
            string[] workoutTypes;
            string workoutCombination = "not used";
            if (filteredWorkouts.Count > 1)
            {
                filteredWorkouts.Sort((x, y) => string.Compare(x.type, y.type));
                workoutTypes = filteredWorkouts.Select(t => t.type).Distinct().ToArray();
                workoutCombination = string.Join(",", workoutTypes);
            }
            else if (filteredWorkouts.Count == 1)
            {
                workoutCombination = filteredWorkouts[0].type;
            }
            else
            {
                //keeps original not used
                workoutCombination = "not used";
            }
            return workoutCombination;
        }



        //Style functions
        private static IEnumerable<XElement> GetLineStyleColorNodes(XDocument xmlDoc)
        {
            //This doesn't work when you send a kml file to it - do these transformations to an Xml
            //first, then we can translate to kml at the very end.
            string xPath = "//Style/LineStyle/color";
            IEnumerable<XElement> colorElements = xmlDoc.XPathSelectElements(xPath).ToList();
            return colorElements;
        }

        private static IEnumerable<XElement> GetPlacemarkNodes(XDocument xmlDoc)
        {
            string xPath = "//Placemark";
            IEnumerable<XElement> placemarkNodes = xmlDoc.XPathSelectElements(xPath).ToList();
            return placemarkNodes;
        }





        // 4)
        internal void StyleWorkoutGroups(List<WorkoutGroup> workoutGroupStyles)
        {
            DeleteExistingStyles();

            int i = 0;
            foreach (WorkoutGroup groupStyle in workoutGroupStyles)
            {
                XElement documentNode = initialTranformedXml.XPathSelectElement("Document");
                string styleName = "style" + i + "line";
                string aabbggrrColor = aabbggrrFromARGB(groupStyle.opacityPercent, groupStyle.lineColor.B, groupStyle.lineColor.G, groupStyle.lineColor.R).Name;
                XElement newStyle = new XElement("Style", new XAttribute("id", styleName));
                newStyle.Add(new XElement("LineStyle"));
                newStyle.XPathSelectElement("LineStyle").Add(new XElement("color", aabbggrrColor));
                newStyle.XPathSelectElement("LineStyle").Add(new XElement("width", groupStyle.lineWeight));

                XElement newStyleHighLight = new XElement("Style", new XAttribute("id", styleName + "Highlight"));
                newStyleHighLight.Add(new XElement("LineStyle"));
                newStyleHighLight.XPathSelectElement("LineStyle").Add(new XElement("color", aabbggrrColor));
                newStyleHighLight.XPathSelectElement("LineStyle").Add(new XElement("width", groupStyle.lineWeight + 3));

                XElement newStyleMap = new XElement("StyleMap", new XAttribute("id", "style" + i));
                XElement pair1 = new XElement("Pair");
                pair1.Add(new XElement("key", "normal"));
                pair1.Add(new XElement("styleUrl", "#" + styleName));
                XElement pair2 = new XElement("Pair");
                pair2.Add(new XElement("key", "highlight"));
                pair2.Add(new XElement("styleUrl", "#" + styleName + "Highlight"));
                newStyleMap.Add(pair1);
                newStyleMap.Add(pair2);

                documentNode.AddFirst(newStyleMap);
                documentNode.AddFirst(newStyleHighLight);
                documentNode.AddFirst(newStyle);
                
                i++;
            }
        }

        private void DeleteExistingStyles()
        {
            //delete any existing styles (in case that they're re-exporting open file)
            IEnumerable<XElement> styleNodesToDelete = initialTranformedXml.XPathSelectElements("Document/Style");
            styleNodesToDelete.Remove();
            IEnumerable<XElement> styleMapNodesToDelete = initialTranformedXml.XPathSelectElements("Document/StyleMap");
            styleMapNodesToDelete.Remove();
        }

        private Color getHexColorFromARGB(int alpha, int red, int green, int blue)
        {
            Color hexColor = Color.FromArgb(alpha, red, green, blue);
            return hexColor;
        }

        private Color aabbggrrFromARGB(int alphaPercent, int blue, int green, int red)
        {
            //Google KML uses the aabbggrr style
            int alpha = (int)Math.Round((alphaPercent * 2.54), 0);
            Color agbrColor = Color.FromArgb(alpha, blue, green, red);
            return agbrColor;
        }




        //Xslt Tranformation functions
        //Create XDocument if all we have is a file path, then we can pass it to the next function
        private static XDocument CreateXDocumentFromFilePath(string xmlFilePath)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            return xDoc;
        }

        /// <summary>
        /// Transforms an XDocument to a new XDocument file using an embedded resource xslt file
        /// </summary>
        /// <param name="inputXDoc">XDocument to be transformed to KML</param>
        /// <param name="xsltFileName">Name of .xslt file in Resources folder (must be Embedded Resource)</param>
        /// <returns>new XDocument</returns>
        private static XDocument TransformXDocumentWithResourcesXslt(XDocument inputXDoc, string xsltFileName)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            XsltSettings settings = new XsltSettings(true, false);

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            writerSettings.IndentChars = "\t";
            writerSettings.Encoding = Encoding.UTF8;

            StringBuilder outputXmlStringBuilder = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(outputXmlStringBuilder, writerSettings);

            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream xsltFileStream = assembly.GetManifestResourceStream("RunningAhead2Kml.Resources." + xsltFileName))
            {
                using (XmlReader reader = XmlReader.Create(xsltFileStream))
                {
                    xslt.Load(reader, settings, new XmlUrlResolver());
                    xslt.Transform(inputXDoc.CreateNavigator(), xmlWriter);
                }
            }
            XDocument newDoc = XDocument.Parse(outputXmlStringBuilder.ToString());
            return newDoc;
        }


        #region Unused Xslt transform method for possible later reference
        //Not used any more - using the methods to transform from embedded resource xslt instead of flat file on disk
        private static XDocument TransformFromLocalXslt(string logXmlFilePath)
        {
            /// Load the style sheet.
            XslCompiledTransform xslt = new XslCompiledTransform(true);
            XsltSettings settings = new XsltSettings(true, false);
            try
            {
                xslt.Load("RA-KML-CourseCollections.xslt", settings, new XmlUrlResolver());
            }
            catch (Exception ex)
            {

                throw;
            }

            // Execute the transform and output the results to a file.
            xslt.Transform(logXmlFilePath, "output.kml");

            XDocument outputKml = XDocument.Load("log_courses.kml");
            return outputKml;
        } 
        #endregion


        internal void ExportTransformedXmlToKml(string saveLocation, List<WorkoutGroup> workoutGroupStyles)
        {
            DeleteRoutesFromNoExportClasses(workoutGroupStyles);

            //use TransformFromResourcesXslt method for transformation code from a file in the resources folder
            //Then just save the doc to a local file in the specified location as in ImportXmlLogFile() method
            XDocument finalOutputKml = TransformXDocumentWithResourcesXslt(initialTranformedXml, "FinalTransformToKml.xslt");

            //save the Kml to a file...
            using (var writer = new XmlTextWriter(saveLocation, new UTF8Encoding()))
            {
                writer.Formatting = Formatting.Indented;
                finalOutputKml.Save(writer);
            }
        }

        private void DeleteRoutesFromNoExportClasses(List<WorkoutGroup> workoutGroupStyles)
        {
            int i = -1;
            foreach (WorkoutGroup styleGroup in workoutGroupStyles)
            {
                i++;
                if (styleGroup.exportGroup == false)
                {
                    //either one of these xpath expressions should do the trick...
                    string xpathExpression = "Document/Placemark[styleUrl ='style" + i + "']";
                    //xpathExpression = "Document/Placemark[ExtendedData/Data[@name = 'workoutTypes']/value ='" + styleGroup.name + "']";
                    IEnumerable<XElement> UnusedRouteNodesToDelete = initialTranformedXml.XPathSelectElements(xpathExpression);
                    UnusedRouteNodesToDelete.Remove();
                }
            }

        }
    }
}
