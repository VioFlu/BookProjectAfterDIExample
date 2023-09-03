namespace BookService.Utility
{
    public static class StringExtensions
    {
        public static string ToSentenceCase(this string bookName)
        {
            if (bookName.Length < 1)
                return bookName;

            return bookName[0].ToString().ToUpper() +
               bookName.Substring(1).ToLower();
        }
    }
}
