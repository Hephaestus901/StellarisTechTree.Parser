grammar StellarisLocale;

localeFile
    : (LOCALEIDENTIFIER|localeValue)*
    ;

localeValue
    : BAREWORD STRING
    ;

LOCALEIDENTIFIER
    : 'l_'BAREWORD
    ;

BAREWORD
   : ([0-9_]+.)?[a-zA-Z][@a-zA-Z_0-9.%-:]*
   ;
   
STRING
   : '"' (~[\r\n])* '"'
   ;
   
NUMBER
   : '-'?[0-9]+'%' 
   | '-'?[0-9]+'.'[0-9]+
   | '-'?[0-9]+
   ;

WS
   : [ \t\n\r]+ -> skip
   ;
   
LINE_COMMENT
   : '#'~[\r\n]* -> channel(HIDDEN)
   ;
   