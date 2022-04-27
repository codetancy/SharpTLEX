parser grammar TimeMLParser;

options {
    tokenVocab=TimeMLLexer;
}

document
    : header miscelaneous* element miscelaneous*
    ;

header
    : '<?' IDENTIFIER attribute* '?>'
    ;

element
    : '<' IDENTIFIER attribute* '>' content'</' IDENTIFIER '>'
    | '<' IDENTIFIER attribute* '/>'
    ;

attribute
    : IDENTIFIER '=' STRING
    ;

content
    : TEXT? ((element | COMMENT) TEXT?)*
    ;

miscelaneous
    : COMMENT
    ;
