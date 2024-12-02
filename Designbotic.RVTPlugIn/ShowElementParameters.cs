using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Text;
using Autodesk.Revit.Attributes;

[Transaction(TransactionMode.Manual)]
public class ShowElementParameters : IExternalCommand
{
    public Result Execute(
        ExternalCommandData commandData,
        ref string message,
        ElementSet elements)
    {
        Document doc = commandData.Application.ActiveUIDocument.Document;

        if (elements.Size == 0)
        {
            message = "No selected elements found.";
            return Result.Failed;
        }

        StringBuilder sb = new StringBuilder();
        foreach (Element element in elements)
        {
            string elementId = element.Id.ToString();
            string elementName = element.Name;
            string elementCategory = element.Category?.Name ?? "Unknown";
            string elementMaterials = GetMaterials(element);

            sb.AppendLine($"ID: {elementId}");
            sb.AppendLine($"Name: {elementName}");
            sb.AppendLine($"Category: {elementCategory}");
            sb.AppendLine($"Materials: {elementMaterials}");
            sb.AppendLine(string.Empty);
        }

        TaskDialog.Show("", sb.ToString());
        return Result.Succeeded;
    }

    private string GetMaterials(Element element)
    {
        var materialIds = element.GetMaterialIds(false);

        if (materialIds.Count == 0)
            return "Materials unset";

        StringBuilder materialsSB = new StringBuilder();
        foreach (var materialId in materialIds)
        {
            var material = element.Document.GetElement(materialId) as Material;
            if (material != null)
                materialsSB.AppendLine(material.Name);
        }
        return materialsSB.ToString().Trim();
    }
}