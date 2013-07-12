INPUT in;
OUTPUT out;

out = SPLIT in PARSE text INTO word USING "\s+" REMOVE "#@";

