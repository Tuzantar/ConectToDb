using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReportsFromBase.Class
{
    internal class ReportPart
    {
        private int _szl_stx_id;
        private string _szl_idpb;
        private string _szl_syntax;
        private string _sp;
        public int szl_stx_id { get { return _szl_stx_id; } set { _szl_stx_id = value; } }
        public string szl_idpb { get { return _szl_idpb; } set { _szl_idpb = value; } }
        public string szl_syntax { get { return _szl_syntax; } set { _szl_syntax = value; } }
        public string sp { get { return _sp; } set { _sp = value; } }
        public ReportPart()
        {
            _szl_idpb = "";
            _szl_syntax = "";
            _sp = "";
        }
    }
}
