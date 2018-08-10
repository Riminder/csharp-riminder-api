using System;
using System.Collections.Generic;

namespace Riminder.response
{
    public class ProfileDocument_list: List<ProfileDocumentListElem>, IResponse
    {
        public ProfileDocument_list(): base()
        { }
    }

    public class ProfileDocumentListElem
    {
        public string type;
        public string file_name;
        public string original_file_name;
        public long file_size;
        public string extension;
        public string url;
        public long timestamp;
    }
}