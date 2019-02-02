using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class Note
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public bool IsNew() => string.IsNullOrEmpty(Filename);
    }
}
