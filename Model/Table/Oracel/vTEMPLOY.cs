using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;


namespace Model.Table.Oracel
{
    public class vTEMPLOY: SetupModel
    {
        public string CODEMPID; // รหัสพนักงาน
        public string NAMEMPT; // full name
        public string CODCOMP; // แผนก
        public string CODCOMPNAME;
        public string CODPOS; //position
        public string CODPOSNAME;
        public DateTime DTEEMPDB; // วันเกิด
        public DateTime? DTEEMPMT; //วันที่เข้างาน
        public DateTime? DTEEFFEX; //วันที่ลาออก
        public int STAEMP; //สถานะ 9 = ลาออก
        public string EMAIL;
        public DateTime? DTEUPD;
        public string DEPCODEOL;
        public string DEPCODEOLNAME;

        public string Code { get; set; }
    }
}
