using SimpleSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Stories
{
    class StoryTable
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string StorycardName { get; set; }

        public string StoryCategory { get; set; }

        public string StorycardText { get; set; }
        // blobs are stored as byte arrays
        public byte[] ImageData { get; set; }

    }
}
