using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.Context {
    public class ContextModel: DbContext {
        public ContextModel() : base("SistemaDB") {}
    }
}