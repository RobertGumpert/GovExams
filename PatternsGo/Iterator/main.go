package main

import (
	"./pattern"
	"fmt"
)

func main() {
	collection := pattern.NewUserCollection(
		&pattern.User{Name: "Vlad"},
		&pattern.User{Name: "Danil"},
		&pattern.User{Name: "Ilya"},
		&pattern.User{Name: "Mihuil"},
		&pattern.User{Name: "Vikusik"},
	)
	iterator := collection.GetIterator()
	for iterator.HasNext() {
		user := iterator.GetNext().(*pattern.User)
		fmt.Print(user.Name, ", ")
	}
}
