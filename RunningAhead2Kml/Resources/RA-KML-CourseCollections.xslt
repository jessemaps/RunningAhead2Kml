<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="/">
    <kml xmlns="http://www.opengis.net/kml/2.2">
      <Document>
        <name>RunningAhead.com Log</name>
        <description>RunningAhead.com training log exported to XML and converted to KML</description>
        <Style id="defaultLine">
          <LineStyle>
            <color>7fff0000</color>
            <width>3</width>
          </LineStyle>
        </Style>
        <Style id="defaultHighlightLine">
          <LineStyle>
            <color>7fff0000</color>
            <width>5</width>
          </LineStyle>
        </Style>
        <StyleMap id="defaultLineStyle">
          <Pair>
            <key>normal</key>
            <styleUrl>#defaultLine</styleUrl>
          </Pair>
          <Pair>
            <key>highlight</key>
            <styleUrl>#defaultHighlightLine</styleUrl>
          </Pair>
        </StyleMap>
        <xsl:for-each select="RunningAHEADLog/CourseCollection/Course">
          <Placemark>
            <name>
              <xsl:value-of select="Name"/>
            </name>
            <description>
              <xsl:value-of select='format-number(DefaultDistance, "#.00")' /><xsl:value-of select="DefaultDistance/@unit"/>s  (Course ID=<xsl:value-of select="@id"/>)
            </description>
            <styleUrl>#defaultLineStyle</styleUrl>
            <ExtendedData>
              <Data name="courseId">
                <value>
                  <xsl:value-of select="@id"/>
                </value>
              </Data>
              <Data name="distance">
                <value>
                  <xsl:value-of select="DefaultDistance"/>
                </value>
              </Data>
              <Data name="distanceUnit">
                <value>
                  <xsl:value-of select="DefaultDistance/@unit"/>
                </value>
              </Data>
              <Data name="surfaces">
                <value>
                  <xsl:for-each select="SurfaceList"><xsl:value-of select="Surface"/>,</xsl:for-each>
                </value>
              </Data>
              <Data name="version">
                <value>
                  <xsl:value-of select="Route/@version"/>
                </value>
              </Data>
            </ExtendedData>
            <LineString>
              <coordinates>
                <xsl:for-each select="Route/WayPoints/LatLng">
                  <xsl:value-of select="@lng"/>,<xsl:value-of select="@lat"/>,0<xsl:text> </xsl:text>

                </xsl:for-each>
              </coordinates>
            </LineString>
          </Placemark>
        </xsl:for-each>
      </Document>
    </kml>
  </xsl:template>

</xsl:stylesheet>
