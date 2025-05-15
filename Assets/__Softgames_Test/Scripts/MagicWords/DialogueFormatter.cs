public class DialogueFormatter
{
    public static void Format(ref Message[] dialogue)
    {
        FormatEmojis(ref dialogue);
    }

    private static void FormatEmojis(ref Message[] dialogue)
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogue[i].text = dialogue[i].text.Replace("{", "<sprite name=\"");
            dialogue[i].text = dialogue[i].text.Replace("}", "\">");
        }
    }
}