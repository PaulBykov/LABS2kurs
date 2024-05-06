package Tech;

import javax.xml.stream.XMLInputFactory;
import javax.xml.stream.XMLStreamConstants;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.XMLStreamReader;
import javax.xml.stream.events.XMLEvent;
import java.io.InputStream;

public class StaxStreamProcessor implements AutoCloseable {
    private static final XMLInputFactory FACTORY = XMLInputFactory.newInstance();

    private final XMLStreamReader reader;

    public StaxStreamProcessor(InputStream is) throws XMLStreamException {
        reader = FACTORY.createXMLStreamReader(is);
    }

    public XMLStreamReader getReader() {
        return reader;
    }


    public boolean startElement(String element, String parent) throws XMLStreamException {
        while (reader.hasNext()) {
            int event = reader.next();
            if (parent != null && event == XMLEvent.END_ELEMENT &&
                    parent.equals(reader.getLocalName())) {
                return false;
            }
            if (event == XMLEvent.START_ELEMENT &&
                    element.equals(reader.getLocalName())) {
                return true;
            }
        }
        return false;
    }

    public void parseClient(XMLStreamReader reader) throws XMLStreamException {
        reader = this.getReader();
        int id = 0;
        String name = "";

        boolean hasID = false;
        while (reader.hasNext()) {
            int event = reader.next();

            switch (event) {
                case XMLStreamConstants.START_ELEMENT:
                    String elementName = reader.getLocalName();
                    switch (elementName) {
                        case "id":
                            if(!hasID){
                                id = Integer.parseInt(reader.getElementText());
                                hasID = true;
                            }
                            break;
                        case "name":
                            name = reader.getElementText();
                            break;
                    }
                    break;
                case XMLStreamConstants.END_ELEMENT:
                    if (reader.getLocalName().equals("client")) {
                        System.out.println("Client ID: " + id);
                        System.out.println("Client Name: " + name);
                        System.out.println("----------------------------------------------------");
                        hasID = false;
                    }
                    break;
            }
        }
    }


    public String getAttribute(String name) throws XMLStreamException {
        return reader.getAttributeValue(null, name);
    }
    public String getText() throws XMLStreamException {
        return reader.getElementText();
    }




    @Override
    public void close() {
        if (reader != null) {
            try {
                reader.close();
            } catch (XMLStreamException e) { // empty
            }
        }
    }
}