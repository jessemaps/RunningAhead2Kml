<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes"/>
  
  <xsl:template match="@* | node()">
    <kml xmlns="http://www.opengis.net/kml/2.2">
      <xsl:copy-of select="/" />
    </kml>
  </xsl:template>
  
</xsl:stylesheet>
