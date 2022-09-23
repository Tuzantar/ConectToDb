using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReportsFromBase
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
        public ReportPart(int szl_stx_id, string szl_idpb, string szl_syntax)
        {
            _szl_stx_id = szl_stx_id;  
            _szl_idpb = szl_idpb;
            _szl_syntax = szl_syntax;
        }
    }
}
