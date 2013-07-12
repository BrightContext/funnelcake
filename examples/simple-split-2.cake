INPUT in;
OUTPUT out;

out = SPLIT in PARSE text INTO word USING "\s+" UNIQUE USECASE;
