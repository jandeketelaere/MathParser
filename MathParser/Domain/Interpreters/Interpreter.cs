﻿using Domain.Expressions;
using Domain.Visitors;

namespace Domain.Interpreters
{
    public class Interpreter : IInterpreter
    {
        public int Interpret(Expression expression)
        {
            var visitor = new CalculationExpressionVisitor();
            visitor.Visit(expression);

            var result = visitor.Result;
            if (result == null)
                throw new System.Exception("boem");

            return result.Value;
        }
    }
}