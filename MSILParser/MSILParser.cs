using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;

namespace MSILParser
{
    /// <summary>
    /// MSILParser implements the abstract RuleParser class and compiles 
    /// the statement to a dynamic method
    /// </summary>
    public class MsilParser : RuleParser
    {
        private ILGenerator il;
        public delegate TReturn ExpressionInvoker<TReturn>();
       
        /// <summary>
        /// This is just a test function that supplies variables with values
        /// </summary>
        public static double GetVar(string var)
        {
            switch (var)
            {
                case "a": return 100;
                case "b": return 200;
                case "c": return 300;
                case "d": return 400;
                default: return 500;
            }
        }
        
        /// <summary>
        /// Builds and returns a dynamic assembly
        /// </summary>
        public Type CompileMsil(string expr)
        {

            // Build the dynamic assembly
            string assemblyName = "Expression";
            string modName = "expression.dll";
            string typeName = "Expression";
            string methodName = "RunExpression";
            AssemblyName name = new AssemblyName(assemblyName);
            AppDomain domain = System.Threading.Thread.GetDomain();
            AssemblyBuilder builder = domain.DefineDynamicAssembly(
              name, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder module = builder.DefineDynamicModule
              (modName, true);
            TypeBuilder typeBuilder = module.DefineType(typeName,
              TypeAttributes.Public | TypeAttributes.Class);
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodName,
              MethodAttributes.HideBySig | MethodAttributes.Static
              | MethodAttributes.Public,
              typeof(Object), new Type[] {  });

            // Create the ILGenerator to insert code into our method body
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            this.il = ilGenerator;

            // Parse the expression.  This will insert MSIL instructions
            this.Run(expr);

            // Finish the method by boxing the result as Double
            this.il.Emit(OpCodes.Conv_R8);
            this.il.Emit(OpCodes.Box, typeof(Double));
            this.il.Emit(OpCodes.Ret);

            // Create and save the Assembly and return the type
            Type myClass = typeBuilder.CreateType();
            builder.Save(modName);
            return myClass;
        }

        #region Semantic Actions for Parse Functions
        
        protected override void matchAnd()
        {
            this.il.Emit(OpCodes.And);
        }

        protected override void matchOr()
        {
            this.il.Emit(OpCodes.Or);
        }

        protected override void matchAdd()
        {
            this.il.Emit(OpCodes.Add);
        }

        protected override void matchComma()
        {
            throw new NotImplementedException();
        }

        protected override void matchDiv()
        {
            this.il.Emit(OpCodes.Div);
        }

        protected override void matchDot()
        {
            throw new NotImplementedException();
        }

        protected override void matchEqual()
        {
            this.il.Emit(OpCodes.Ceq);
        }

        protected override void matchFunc()
        {
            throw new NotImplementedException();
        }

        protected override void matchGE()
        {
            throw new NotImplementedException();
        }

        protected override void matchGT()
        {
            this.il.Emit(OpCodes.Cgt);
        }

        protected override void matchLE()
        {
            throw new NotImplementedException();
        }

        protected override void matchLT()
        {
            this.il.Emit(OpCodes.Clt);
        }

        protected override void matchMod()
        {
            throw new NotImplementedException();
        }

        protected override void matchMult()
        {
            this.il.Emit(OpCodes.Mul);
        }

        protected override void matchNeg()
        {
            this.il.Emit(OpCodes.Neg);
        }

        protected override void matchNegate()
        {
            throw new NotImplementedException();
        }

        protected override void matchNotEqual()
        {
            throw new NotImplementedException();
        }

        protected override void matchParen()
        {
            // No action required
        }

        protected override void matchSub()
        {
            this.il.Emit(OpCodes.Sub);
        }

        protected override void matchVal()
        {
            switch (this.tokenValue.Type)
            {
                case VariantType.BOOL:
                    this.il.Emit(OpCodes.Ldc_I4, Convert.ToInt32(this.tokenValue.Value));
                    break;
                case VariantType.DOUBLE:
                    this.il.Emit(OpCodes.Ldc_R8, Convert.ToDouble(this.tokenValue.Value));
                    //this.il.Emit(OpCodes.Box, typeof(Double));
                    break;
                case VariantType.INT:
                    this.il.Emit(OpCodes.Ldc_R8, Convert.ToDouble(this.tokenValue.Value));
                    break;
                case VariantType.STRING:
                    this.il.Emit(OpCodes.Ldstr, Convert.ToString(this.tokenValue.Value));
                    break;
                default:
                    throw new Exception("Invalid TokenType");
            }
        }

        protected override void matchVar()
        {
            string s = tokenValue.ToString();
            il.Emit(OpCodes.Ldstr, s);
            il.Emit(OpCodes.Call, typeof(MsilParser).GetMethod("GetVar", new Type[] { typeof(string) }));
        }

        protected override void matchXor()
        {
            this.il.Emit(OpCodes.Xor);
        }
        #endregion
    }
}