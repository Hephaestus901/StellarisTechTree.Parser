//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\Projects\.Net\StellarisTechTree\src\StellarisTechTree.WebApp\StellarisLocale.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System.CodeDom.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;

namespace StellarisTechTree.Infrastructure.Antlr.StellarisLocale;

[GeneratedCode("ANTLR", "4.7.2")]
[CLSCompliant(false)]
public partial class StellarisLocaleLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		LOCALEIDENTIFIER=1, BAREWORD=2, STRING=3, NUMBER=4, WS=5, LINE_COMMENT=6;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"LOCALEIDENTIFIER", "BAREWORD", "STRING", "NUMBER", "WS", "LINE_COMMENT"
	};


	public StellarisLocaleLexer(ICharStream input)
		: this(input, Console.Out, Console.Error) { }

	public StellarisLocaleLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "LOCALEIDENTIFIER", "BAREWORD", "STRING", "NUMBER", "WS", "LINE_COMMENT"
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

	public override string GrammarFileName { get { return "StellarisLocale.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static StellarisLocaleLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\b', 'U', '\b', '\x1', '\x4', '\x2', '\t', '\x2', '\x4', 
		'\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', 
		'\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', 
		'\x3', '\a', '\x3', '\x17', '\n', '\x3', '\f', '\x3', '\xE', '\x3', '\x1A', 
		'\v', '\x3', '\x3', '\x4', '\x3', '\x4', '\a', '\x4', '\x1E', '\n', '\x4', 
		'\f', '\x4', '\xE', '\x4', '!', '\v', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x5', '\x5', '\x5', '&', '\n', '\x5', '\x3', '\x5', '\x6', '\x5', 
		')', '\n', '\x5', '\r', '\x5', '\xE', '\x5', '*', '\x3', '\x5', '\x3', 
		'\x5', '\x5', '\x5', '/', '\n', '\x5', '\x3', '\x5', '\x6', '\x5', '\x32', 
		'\n', '\x5', '\r', '\x5', '\xE', '\x5', '\x33', '\x3', '\x5', '\x3', '\x5', 
		'\x6', '\x5', '\x38', '\n', '\x5', '\r', '\x5', '\xE', '\x5', '\x39', 
		'\x3', '\x5', '\x5', '\x5', '=', '\n', '\x5', '\x3', '\x5', '\x6', '\x5', 
		'@', '\n', '\x5', '\r', '\x5', '\xE', '\x5', '\x41', '\x5', '\x5', '\x44', 
		'\n', '\x5', '\x3', '\x6', '\x6', '\x6', 'G', '\n', '\x6', '\r', '\x6', 
		'\xE', '\x6', 'H', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', 
		'\a', '\a', 'O', '\n', '\a', '\f', '\a', '\xE', '\a', 'R', '\v', '\a', 
		'\x3', '\a', '\x3', '\a', '\x2', '\x2', '\b', '\x3', '\x3', '\x5', '\x4', 
		'\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\x3', '\x2', '\a', 
		'\x4', '\x2', '\x43', '\\', '\x63', '|', '\x6', '\x2', '\'', '<', '\x42', 
		'\\', '\x61', '\x61', '\x63', '|', '\x4', '\x2', '\f', '\f', '\xF', '\xF', 
		'\x3', '\x2', '\x32', ';', '\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', 
		'\"', '\x2', '\x61', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x3', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '\x14', '\x3', '\x2', '\x2', '\x2', '\a', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\t', '\x43', '\x3', '\x2', '\x2', '\x2', 
		'\v', '\x46', '\x3', '\x2', '\x2', '\x2', '\r', 'L', '\x3', '\x2', '\x2', 
		'\x2', '\xF', '\x10', '\a', 'n', '\x2', '\x2', '\x10', '\x11', '\a', '\x61', 
		'\x2', '\x2', '\x11', '\x12', '\x3', '\x2', '\x2', '\x2', '\x12', '\x13', 
		'\x5', '\x5', '\x3', '\x2', '\x13', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'\x14', '\x18', '\t', '\x2', '\x2', '\x2', '\x15', '\x17', '\t', '\x3', 
		'\x2', '\x2', '\x16', '\x15', '\x3', '\x2', '\x2', '\x2', '\x17', '\x1A', 
		'\x3', '\x2', '\x2', '\x2', '\x18', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'\x18', '\x19', '\x3', '\x2', '\x2', '\x2', '\x19', '\x6', '\x3', '\x2', 
		'\x2', '\x2', '\x1A', '\x18', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x1F', 
		'\a', '$', '\x2', '\x2', '\x1C', '\x1E', '\n', '\x4', '\x2', '\x2', '\x1D', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', '\x1E', '!', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1F', ' ', '\x3', 
		'\x2', '\x2', '\x2', ' ', '\"', '\x3', '\x2', '\x2', '\x2', '!', '\x1F', 
		'\x3', '\x2', '\x2', '\x2', '\"', '#', '\a', '$', '\x2', '\x2', '#', '\b', 
		'\x3', '\x2', '\x2', '\x2', '$', '&', '\a', '/', '\x2', '\x2', '%', '$', 
		'\x3', '\x2', '\x2', '\x2', '%', '&', '\x3', '\x2', '\x2', '\x2', '&', 
		'(', '\x3', '\x2', '\x2', '\x2', '\'', ')', '\t', '\x5', '\x2', '\x2', 
		'(', '\'', '\x3', '\x2', '\x2', '\x2', ')', '*', '\x3', '\x2', '\x2', 
		'\x2', '*', '(', '\x3', '\x2', '\x2', '\x2', '*', '+', '\x3', '\x2', '\x2', 
		'\x2', '+', ',', '\x3', '\x2', '\x2', '\x2', ',', '\x44', '\a', '\'', 
		'\x2', '\x2', '-', '/', '\a', '/', '\x2', '\x2', '.', '-', '\x3', '\x2', 
		'\x2', '\x2', '.', '/', '\x3', '\x2', '\x2', '\x2', '/', '\x31', '\x3', 
		'\x2', '\x2', '\x2', '\x30', '\x32', '\t', '\x5', '\x2', '\x2', '\x31', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\x32', '\x33', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\x31', '\x3', '\x2', '\x2', '\x2', '\x33', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '\x34', '\x35', '\x3', '\x2', '\x2', '\x2', '\x35', 
		'\x37', '\a', '\x30', '\x2', '\x2', '\x36', '\x38', '\t', '\x5', '\x2', 
		'\x2', '\x37', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', '\x39', '\x3', 
		'\x2', '\x2', '\x2', '\x39', '\x37', '\x3', '\x2', '\x2', '\x2', '\x39', 
		':', '\x3', '\x2', '\x2', '\x2', ':', '\x44', '\x3', '\x2', '\x2', '\x2', 
		';', '=', '\a', '/', '\x2', '\x2', '<', ';', '\x3', '\x2', '\x2', '\x2', 
		'<', '=', '\x3', '\x2', '\x2', '\x2', '=', '?', '\x3', '\x2', '\x2', '\x2', 
		'>', '@', '\t', '\x5', '\x2', '\x2', '?', '>', '\x3', '\x2', '\x2', '\x2', 
		'@', '\x41', '\x3', '\x2', '\x2', '\x2', '\x41', '?', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\x42', '\x3', '\x2', '\x2', '\x2', '\x42', '\x44', '\x3', 
		'\x2', '\x2', '\x2', '\x43', '%', '\x3', '\x2', '\x2', '\x2', '\x43', 
		'.', '\x3', '\x2', '\x2', '\x2', '\x43', '<', '\x3', '\x2', '\x2', '\x2', 
		'\x44', '\n', '\x3', '\x2', '\x2', '\x2', '\x45', 'G', '\t', '\x6', '\x2', 
		'\x2', '\x46', '\x45', '\x3', '\x2', '\x2', '\x2', 'G', 'H', '\x3', '\x2', 
		'\x2', '\x2', 'H', '\x46', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x3', 
		'\x2', '\x2', '\x2', 'I', 'J', '\x3', '\x2', '\x2', '\x2', 'J', 'K', '\b', 
		'\x6', '\x2', '\x2', 'K', '\f', '\x3', '\x2', '\x2', '\x2', 'L', 'P', 
		'\a', '%', '\x2', '\x2', 'M', 'O', '\n', '\x4', '\x2', '\x2', 'N', 'M', 
		'\x3', '\x2', '\x2', '\x2', 'O', 'R', '\x3', '\x2', '\x2', '\x2', 'P', 
		'N', '\x3', '\x2', '\x2', '\x2', 'P', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'Q', 'S', '\x3', '\x2', '\x2', '\x2', 'R', 'P', '\x3', '\x2', '\x2', '\x2', 
		'S', 'T', '\b', '\a', '\x3', '\x2', 'T', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'\xF', '\x2', '\x18', '\x1F', '%', '*', '.', '\x33', '\x39', '<', '\x41', 
		'\x43', 'H', 'P', '\x4', '\b', '\x2', '\x2', '\x2', '\x3', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}