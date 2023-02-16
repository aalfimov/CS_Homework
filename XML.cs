using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        // Создаем новый XML-документ
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("orders");
        xmlDoc.AppendChild(rootNode);

        // Создаем первый заказ
        XmlNode orderNode1 = CreateOrderNode(xmlDoc, "123456", "2022-02-14");
        CreateProductNode(xmlDoc, orderNode1, "Apple", "10", "1.5");
        CreateProductNode(xmlDoc, orderNode1, "Banana", "5", "2");
        rootNode.AppendChild(orderNode1);

        // Создаем второй заказ
        XmlNode orderNode2 = CreateOrderNode(xmlDoc, "789012", "2022-02-15");
        CreateProductNode(xmlDoc, orderNode2, "Orange", "7", "2.2");
        CreateProductNode(xmlDoc, orderNode2, "Grape", "15", "3");
        CreateProductNode(xmlDoc, orderNode2, "Mango", "4", "4.5");
        rootNode.AppendChild(orderNode2);

        // Сохраняем XML-документ в файл
        XmlTextWriter writer = new XmlTextWriter("orders.xml", null);
        writer.Formatting = Formatting.Indented;
        xmlDoc.WriteContentTo(writer);
        writer.Close();

        // Читаем информацию из файла и выводим ее на экран
        XmlTextReader reader = new XmlTextReader("orders.xml");
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "order")
            {
                Console.WriteLine($"Order ID: {reader.GetAttribute("id")}");
                Console.WriteLine($"Order Date: {reader.GetAttribute("date")}");
            }
            else if (reader.NodeType == XmlNodeType.Element && reader.Name == "product")
            {
                Console.WriteLine($"Product Name: {reader.GetAttribute("name")}");
                Console.WriteLine($"Quantity: {reader.GetAttribute("quantity")}");
                Console.WriteLine($"Price: {reader.GetAttribute("price")}");
            }
        }
        reader.Close();

        Console.ReadLine();
    }

    static XmlNode CreateOrderNode(XmlDocument xmlDoc, string id, string date)
    {
        XmlNode orderNode = xmlDoc.CreateElement("order");
        orderNode.Attributes.Append(CreateAttribute(xmlDoc, "id", id));
        orderNode.Attributes.Append(CreateAttribute(xmlDoc, "date", date));
        return orderNode;
    }

    static void CreateProductNode(XmlDocument xmlDoc, XmlNode orderNode, string name, string quantity, string price)
    {
        XmlNode productNode = xmlDoc.CreateElement("product");
        productNode.Attributes.Append(CreateAttribute(xmlDoc, "name", name));
        productNode.Attributes.Append(CreateAttribute(xmlDoc, "quantity", quantity));
        productNode.Attributes.Append(CreateAttribute(xmlDoc, "price", price));
        orderNode.AppendChild(productNode);
    }

    static XmlAttribute CreateAttribute(XmlDocument xmlDoc, string name, string value)
    {
        XmlAttribute attribute = xmlDoc.CreateAttribute(name);
        attribute.Value = value;
        return attribute;
    }
}
