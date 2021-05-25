package main

import (
	"./pattern"
	"fmt"
)

func main() {
	pizza := pattern.NewBaseFrenchPizza()
	fmt.Println("Base price is: ", pizza.GetPrice())

	pizza = pattern.AddIngredientTomatoTopping(pizza)
	fmt.Println("Decorate tomato price is: ", pizza.GetPrice())

	pizza = pattern.AddIngredientCheeseTopping(pizza)
	fmt.Println("Decorate cheese price is: ", pizza.GetPrice())
}
