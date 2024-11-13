module CBMLanguage.Ast

type Type =
    | ByteType
    | ShortType
    | IntType
    | LongType
    | SingleType
    | DoubleType
    | BoolType
    | CharType
    | StringType
    | UnitType

type Identifier = string
type Param = Identifier * Type
type Params = Param list

type Literal =
    | Byte of byte
    | Short of int16
    | Int of int32
    | Long of int64
    | Single of single
    | Double of double
    | Char of char
    | String of string
    | Bool of bool


type RelationalOperator =
    | LessThan
    | LessThanOrEqual
    | GreaterThan
    | GreaterThanOrEqual
    | NotEqual
    | Equal

type LogicalOperator =
    | And
    | Or
    | Xor

type ArithmeticOperator =
    | Add
    | Subtract
    | Multiply
    | Divide
    | Modulus

type BitwiseOperator =
    | LogicalShiftLeft
    | LogicalShiftRight
    | ArithmeticShiftLeft
    | ArithmeticShiftRight
    | BitwiseAnd
    | BitwiseOr
    | BitwiseXor

type UnaryOperator =
    | Plus
    | Negate
    | BitwiseNot

type BinaryOperator =
    | Relational of RelationalOperator
    | Logical of LogicalOperator
    | Arithmetic of ArithmeticOperator
    | Bitwise of BitwiseOperator

type Condition =
    | Comparison of Expr * RelationalOperator * Expr
    | Logical of Condition * LogicalOperator * Condition
    | Not of Condition

and Expr =
    | Literal of Literal
    | Variable of Identifier
    | UnaryOp of UnaryOperator * Expr
    | BinaryOp of Expr * BinaryOperator * Expr
    | Assignment of Identifier * Expr
    | FunctionCall of Identifier * Expr list

type Statements = Stmt list
and Stmt =
    | Expression of Expr
    | If of Condition * Statements * Stmt list option
    | While of Condition * Statements
    | For of Identifier * Expr * Expr * Statements
    | Return of Expr option
    | Block of Statements
    | VarDeclaration of Identifier * Type option * Expr option
    | FuncDeclaration of Identifier * Params * Type * Statements

type Program = Program of Stmt list
