package main

import (
	"github.com/gin-gonic/gin"
	"log"
)

type stringTemplate struct {
	line     string
	parent   *stringTemplate
	children []*stringTemplate
}

// {a1 {b1|b2}|{c1|c2}|a2}! Я рад тебя {увидеть|feelings}
func foo2(runes []rune, index int, header string) ([]string, int) {
	ways := make([]string, 0)
	flag := index
	for i := index; i < len(runes); i++ {
		log.Println(string(runes[i]))
		if runes[i+1] == '}' {
			ways = append(ways, header + string(runes[flag:i+1]))
			return ways, i+2
		}
		if runes[i] == '|' && runes[i+1] != '{' {
			ways = append(ways, header + string(runes[flag:i]))
			flag = i+1
		}
		if runes[i] == '|' && runes[i+1] == '{' {
			children, swap := foo2(runes, i+2, "")
			ways = append(ways, children...)
			i = swap
			flag = i + 1
		}
		if  runes[i] == '{' && runes[i+1] != '|'{
			children, swap := foo2(runes, i+1, string(runes[flag : i]))
			ways = append(ways, children...)
			i = swap
			flag = i + 1
		}
	}
	return ways, -1
}

func foo(runes []rune, index int, root *stringTemplate) int {
	flag := index

	ways := make([]string, 0)
	for i := index; i < len(runes); i++ {
		log.Println(string(runes[i]))
		if runes[i+1] == '|' {

			ways = append(ways, string(runes[flag:i+1]))
			child := &stringTemplate{
				line:     string(runes[flag : i+1]),
				parent:   root,
				children: nil,
			}
			root.children = append(
				root.children,
				child,
			)
			i = i + 1
			flag = i + 1
		}
		if runes[i+1] == '}' {
			child := &stringTemplate{
				line:     string(runes[flag : i+1]),
				parent:   root,
				children: nil,
			}
			root.children = append(
				root.children,
				child,
			)
			return i + 1
		}
		if runes[i] == '{' {
			child := &stringTemplate{
				line:     "",
				parent:   root,
				children: make([]*stringTemplate, 0),
			}
			root.children = append(
				root.children,
				child,
			)
			i = foo(runes, i+1, child)
			flag = i + 1
		}
	}
	return -1
}

func createLine(temp string) {
	//root := &stringTemplate{
	//	line:     "",
	//	parent:   nil,
	//	children: make([]*stringTemplate, 0),
	//}
	//_ = foo(
	//	[]rune(temp),
	//	1,
	//	root,
	//)
	ways, _ := foo2(
		[]rune(temp),
		1,
		"",
	)
	log.Println(ways)
	return
}

func main() {
	stirngTemplate := "{a1 {b1|b2,{c1|c2}|b3 - {c3|c4}}|a2}! Я рад тебя {увидеть|feelings}" // -> a1! or b1! or b2
	createLine(stirngTemplate)
	//buildStringFromTemplate(stirngTemplate)
	//startServer()
}

func startServer() {
	engine := gin.Default()

	err := engine.Run(":54000")
	if err != nil {
		log.Fatal(err)
	}
}
