package main

import (
	"./pattern"
	"fmt"
)

func main() {
	f1 := pattern.CreateFile("home_1.txt")
	f2 := pattern.CreateFile("home_2.txt")
	f3 := pattern.CreateFile("main.go")
	//
	dir1 := pattern.CreateDirectory("/go", f3)
	dir2 := pattern.CreateDirectory("/home", f1, f2, dir1)
	dir3 := pattern.CreateDirectory("/etc")
	//
	root := pattern.CreateDirectory("/", dir2, dir3)
	//
	fmt.Println("File is exist? : ", root.Search("main.go"))
}
