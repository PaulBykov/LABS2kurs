package Tech;

import javax.xml.XMLConstants;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;
import org.xml.sax.SAXException;
import java.io.File;
import java.io.IOException;


public class XMLValidator {

    public static void start() {
        String xmlFilePath = "files/data.xml";
        String xsdFilePath = "files/schema.xsd";

        if (validateXMLSchema(xsdFilePath, xmlFilePath)) {
            System.out.println("XML is valid according to XSD.");
            // Дополнительные действия для обработки XML
        } else {
            System.out.println("XML is not valid according to XSD.");
        }
    }

    public static boolean validateXMLSchema(String xsdPath, String xmlPath) {
        try {
            SchemaFactory factory = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
            Schema schema = factory.newSchema(new File(xsdPath));
            Validator validator = schema.newValidator();
            validator.validate(new StreamSource(new File(xmlPath)));
            return true;
        } catch (IOException | SAXException e) {
            System.out.println("Exception: " + e.getMessage());
            return false;
        }
    }
}