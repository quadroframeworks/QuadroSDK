using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Authorization
{
    public class InvitationAcceptationResult
    {
        public bool Succes { get; set; }
        public string? CompanyName { get; set; }
        public InvitationAcceptationResultState State { get; set; }
    }

    public enum InvitationAcceptationResultState
    {
        Failed = 0,
        Passed = 1,
        Expired = 2,
    }
}
