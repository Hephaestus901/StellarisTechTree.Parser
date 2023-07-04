//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from d:\Projects\.Net\StellarisTechTree\TestApp\Stellaris.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class StellarisParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, BOOLEAN=3, VARIABLE=4, SPECIFIER=5, NUMBER=6, DATE=7, 
		BAREWORD=8, STRING=9, WS=10, LINE_COMMENT=11;
	public const int
		RULE_file = 0, RULE_map = 1, RULE_pair = 2, RULE_var = 3, RULE_array = 4, 
		RULE_value = 5;
	public static readonly string[] ruleNames = {
		"file", "map", "pair", "var", "array", "value"
	};

	private static readonly string[] _LiteralNames = {
		null, "'{'", "'}'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "BOOLEAN", "VARIABLE", "SPECIFIER", "NUMBER", "DATE", 
		"BAREWORD", "STRING", "WS", "LINE_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Stellaris.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static StellarisParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public StellarisParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public StellarisParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class FileContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PairContext[] pair() {
			return GetRuleContexts<PairContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public PairContext pair(int i) {
			return GetRuleContext<PairContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public VarContext[] var() {
			return GetRuleContexts<VarContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public VarContext var(int i) {
			return GetRuleContext<VarContext>(i);
		}
		public FileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_file; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisVisitor<TResult> typedVisitor = visitor as IStellarisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFile(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FileContext file() {
		FileContext _localctx = new FileContext(Context, State);
		EnterRule(_localctx, 0, RULE_file);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 16;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==VARIABLE || _la==BAREWORD) {
				{
				State = 14;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case BAREWORD:
					{
					State = 12;
					pair();
					}
					break;
				case VARIABLE:
					{
					State = 13;
					var();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 18;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MapContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PairContext[] pair() {
			return GetRuleContexts<PairContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public PairContext pair(int i) {
			return GetRuleContext<PairContext>(i);
		}
		public MapContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_map; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisVisitor<TResult> typedVisitor = visitor as IStellarisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMap(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MapContext map() {
		MapContext _localctx = new MapContext(Context, State);
		EnterRule(_localctx, 2, RULE_map);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 19;
			Match(T__0);
			State = 23;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==BAREWORD) {
				{
				{
				State = 20;
				pair();
				}
				}
				State = 25;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 26;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PairContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BAREWORD() { return GetToken(StellarisParser.BAREWORD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SPECIFIER() { return GetToken(StellarisParser.SPECIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public PairContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_pair; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisVisitor<TResult> typedVisitor = visitor as IStellarisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPair(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PairContext pair() {
		PairContext _localctx = new PairContext(Context, State);
		EnterRule(_localctx, 4, RULE_pair);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 28;
			Match(BAREWORD);
			State = 29;
			Match(SPECIFIER);
			State = 30;
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode VARIABLE() { return GetToken(StellarisParser.VARIABLE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SPECIFIER() { return GetToken(StellarisParser.SPECIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER() { return GetToken(StellarisParser.NUMBER, 0); }
		public VarContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_var; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisVisitor<TResult> typedVisitor = visitor as IStellarisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVar(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarContext var() {
		VarContext _localctx = new VarContext(Context, State);
		EnterRule(_localctx, 6, RULE_var);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 32;
			Match(VARIABLE);
			State = 33;
			Match(SPECIFIER);
			State = 34;
			Match(NUMBER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ArrayContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext[] value() {
			return GetRuleContexts<ValueContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value(int i) {
			return GetRuleContext<ValueContext>(i);
		}
		public ArrayContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_array; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisVisitor<TResult> typedVisitor = visitor as IStellarisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitArray(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ArrayContext array() {
		ArrayContext _localctx = new ArrayContext(Context, State);
		EnterRule(_localctx, 8, RULE_array);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 36;
			Match(T__0);
			State = 38;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 37;
				value();
				}
				}
				State = 40;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << BOOLEAN) | (1L << VARIABLE) | (1L << NUMBER) | (1L << DATE) | (1L << BAREWORD) | (1L << STRING))) != 0) );
			State = 42;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER() { return GetToken(StellarisParser.NUMBER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BOOLEAN() { return GetToken(StellarisParser.BOOLEAN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DATE() { return GetToken(StellarisParser.DATE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(StellarisParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode VARIABLE() { return GetToken(StellarisParser.VARIABLE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BAREWORD() { return GetToken(StellarisParser.BAREWORD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public MapContext map() {
			return GetRuleContext<MapContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ArrayContext array() {
			return GetRuleContext<ArrayContext>(0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IStellarisVisitor<TResult> typedVisitor = visitor as IStellarisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 10, RULE_value);
		try {
			State = 52;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 44;
				Match(NUMBER);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 45;
				Match(BOOLEAN);
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 46;
				Match(DATE);
				}
				break;
			case 4:
				EnterOuterAlt(_localctx, 4);
				{
				State = 47;
				Match(STRING);
				}
				break;
			case 5:
				EnterOuterAlt(_localctx, 5);
				{
				State = 48;
				Match(VARIABLE);
				}
				break;
			case 6:
				EnterOuterAlt(_localctx, 6);
				{
				State = 49;
				Match(BAREWORD);
				}
				break;
			case 7:
				EnterOuterAlt(_localctx, 7);
				{
				State = 50;
				map();
				}
				break;
			case 8:
				EnterOuterAlt(_localctx, 8);
				{
				State = 51;
				array();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\r', '\x39', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x3', '\x2', 
		'\a', '\x2', '\x11', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '\x14', '\v', 
		'\x2', '\x3', '\x3', '\x3', '\x3', '\a', '\x3', '\x18', '\n', '\x3', '\f', 
		'\x3', '\xE', '\x3', '\x1B', '\v', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x6', '\x6', ')', '\n', '\x6', '\r', '\x6', '\xE', '\x6', '*', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x5', '\a', '\x37', 
		'\n', '\a', '\x3', '\a', '\x2', '\x2', '\b', '\x2', '\x4', '\x6', '\b', 
		'\n', '\f', '\x2', '\x2', '\x2', '=', '\x2', '\x12', '\x3', '\x2', '\x2', 
		'\x2', '\x4', '\x15', '\x3', '\x2', '\x2', '\x2', '\x6', '\x1E', '\x3', 
		'\x2', '\x2', '\x2', '\b', '\"', '\x3', '\x2', '\x2', '\x2', '\n', '&', 
		'\x3', '\x2', '\x2', '\x2', '\f', '\x36', '\x3', '\x2', '\x2', '\x2', 
		'\xE', '\x11', '\x5', '\x6', '\x4', '\x2', '\xF', '\x11', '\x5', '\b', 
		'\x5', '\x2', '\x10', '\xE', '\x3', '\x2', '\x2', '\x2', '\x10', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x11', '\x14', '\x3', '\x2', '\x2', '\x2', 
		'\x12', '\x10', '\x3', '\x2', '\x2', '\x2', '\x12', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x13', '\x3', '\x3', '\x2', '\x2', '\x2', '\x14', '\x12', 
		'\x3', '\x2', '\x2', '\x2', '\x15', '\x19', '\a', '\x3', '\x2', '\x2', 
		'\x16', '\x18', '\x5', '\x6', '\x4', '\x2', '\x17', '\x16', '\x3', '\x2', 
		'\x2', '\x2', '\x18', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x19', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x19', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'\x1A', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x19', '\x3', '\x2', 
		'\x2', '\x2', '\x1C', '\x1D', '\a', '\x4', '\x2', '\x2', '\x1D', '\x5', 
		'\x3', '\x2', '\x2', '\x2', '\x1E', '\x1F', '\a', '\n', '\x2', '\x2', 
		'\x1F', ' ', '\a', '\a', '\x2', '\x2', ' ', '!', '\x5', '\f', '\a', '\x2', 
		'!', '\a', '\x3', '\x2', '\x2', '\x2', '\"', '#', '\a', '\x6', '\x2', 
		'\x2', '#', '$', '\a', '\a', '\x2', '\x2', '$', '%', '\a', '\b', '\x2', 
		'\x2', '%', '\t', '\x3', '\x2', '\x2', '\x2', '&', '(', '\a', '\x3', '\x2', 
		'\x2', '\'', ')', '\x5', '\f', '\a', '\x2', '(', '\'', '\x3', '\x2', '\x2', 
		'\x2', ')', '*', '\x3', '\x2', '\x2', '\x2', '*', '(', '\x3', '\x2', '\x2', 
		'\x2', '*', '+', '\x3', '\x2', '\x2', '\x2', '+', ',', '\x3', '\x2', '\x2', 
		'\x2', ',', '-', '\a', '\x4', '\x2', '\x2', '-', '\v', '\x3', '\x2', '\x2', 
		'\x2', '.', '\x37', '\a', '\b', '\x2', '\x2', '/', '\x37', '\a', '\x5', 
		'\x2', '\x2', '\x30', '\x37', '\a', '\t', '\x2', '\x2', '\x31', '\x37', 
		'\a', '\v', '\x2', '\x2', '\x32', '\x37', '\a', '\x6', '\x2', '\x2', '\x33', 
		'\x37', '\a', '\n', '\x2', '\x2', '\x34', '\x37', '\x5', '\x4', '\x3', 
		'\x2', '\x35', '\x37', '\x5', '\n', '\x6', '\x2', '\x36', '.', '\x3', 
		'\x2', '\x2', '\x2', '\x36', '/', '\x3', '\x2', '\x2', '\x2', '\x36', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\x36', '\x31', '\x3', '\x2', '\x2', 
		'\x2', '\x36', '\x32', '\x3', '\x2', '\x2', '\x2', '\x36', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x36', '\x34', '\x3', '\x2', '\x2', '\x2', '\x36', 
		'\x35', '\x3', '\x2', '\x2', '\x2', '\x37', '\r', '\x3', '\x2', '\x2', 
		'\x2', '\a', '\x10', '\x12', '\x19', '*', '\x36',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
