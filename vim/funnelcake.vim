" Vim syntax file
" Language: BrightContext Funnel Cake
" Maintainer: Steven Fusco <sfusco@brightcontext.com>
" Latest Revision: 12 July 2013

if exists("b:current_syntax")
  finish
endif

syn keyword funnelcakeConstant MIN MAX ALL

syn keyword funnelcakeFunc min max latest
syn keyword funnelcakeFunc sum count avg
syn keyword funnelcakeFunc sumActiveUser countActiveUser avgActiveUser
syn keyword funnelcakeFunc numResponseActiveUser
syn keyword funnelcakeFunc toLowerCase toUpperCase isEmpty inList
syn match funnelcakeFunc 'contains'

syn keyword funnelcakeStatement TIMEONLY REFRESHRATE

syn keyword funnelcakeStreamCommand FILTER GROUP SPLIT TRANSFORM MERGE
syn keyword funnelcakeStreamCommandSecondary AGG PARSE REMOVE WHERE LEADERBOARD TOP
syn keyword funnelcakeStreamKeyword BY AS WITH USING INTO UNIQUE USECASE

syn keyword funnelcakeType INPUT OUTPUT FC

syn match funnelcakeConstant /true/
syn match funnelcakeConstant /false/
syn match funnelcakeNumber /\d\+/
syn match funnelcakeComment /^\/\/.*/
syn match funnelcakeDelimiter /[\.\,;]/
syn match funnelcakeSpecial /[\[\]\(\)=]/
syn match funnelcakeComparitor /[\<\>]/
syn match funnelcakeComparitor /==/
syn match funnelcakeComparitor />=/
syn match funnelcakeComparitor /=</
syn match funnelcakeComparitor /!=/
syn match funnelcakeOperator /&&/
syn match funnelcakeOperator /\!/
syn match funnelcakeOperator /+/
syn match funnelcakeOperator /-/
syntax region funnelcakeString start=/\v"/ skip=/\v\\./ end=/\v"/

let b:current_syntax = "funnelcake"

hi def link funnelcakeComment Comment
hi def link funnelcakeConstant Constant
hi def link funnelcakeNumber Constant
hi def link funnelcakeFunc Function
hi def link funnelcakeStreamCommand Macro
hi def link funnelcakeStreamCommandSecondary Label
hi def link funnelcakeStreamKeyword Keyword
hi def link funnelcakeType Type
hi def link funnelcakeStatement Statement
hi def link funnelcakeDelimiter Delimiter
hi def link funnelcakeComparitor Operator
hi def link funnelcakeOperator Operator
hi def link funnelcakeSpecial SpecialChar
hi def link funnelcakeString String
