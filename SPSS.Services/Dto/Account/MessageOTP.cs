using System.Collections.Generic;

namespace SPSS.Dto.Account
{
    public class MessageOTP
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public MessageOTP(IEnumerable<string> to, string subject, string content)
        {
            To = new List<string>(to);
            Subject = subject;
            Content = content;
        }
    }
}
