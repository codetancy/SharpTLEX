lexer grammar TimeMLLexer;

COMMENT: '<!--' .*? '-->';

OPEN_ANGLE: '<' -> pushMode(inside);
OPEN_CLOSING_ANGLE: '</' -> pushMode(inside);
SPECIAL_OPEN_ANGLE: '<?' -> pushMode(inside);

WS : [ \t\r\n]+ -> skip;
TEXT: ~[<]+;

mode inside;

CLOSE_ANGLE: '>' -> popMode;
SLASH_CLOSE_ANGLE: '/>' -> popMode;
SPECIAL_CLOSE_ANGLE: '?>' -> popMode;
EQUAL: '=';
COLON: ':';
DOUBLE_QUOTE: '"';
SINGLE_QUOTE: '\'';

STRING
    : '"' .*? '"'
    | '\'' .*? '\''
    ;

IDENTIFIER
    : ALPHA+ (COLON? (ALPHA | DIGIT)+)*;

fragment ALPHA: [a-zA-Z];
fragment DIGIT: [0-9];

S: [ \t\r\n]+ -> skip;
