package pattern


// Докоратор компонента #1
type ingredientTomatoTopping struct {
	pizza IPizza
}

func AddIngredientTomatoTopping(pizza IPizza) IPizza {
	return &ingredientTomatoTopping{
		pizza: pizza,
	}
}

func (decorator *ingredientTomatoTopping) GetPrice() int {
	return decorator.pizza.GetPrice() + 2
}


// Докоратор компонента #2
type ingredientCheeseTopping struct {
	pizza IPizza
}

func AddIngredientCheeseTopping(pizza IPizza) IPizza {
	return &ingredientCheeseTopping{
		pizza: pizza,
	}
}

func (decorator *ingredientCheeseTopping) GetPrice() int {
	return decorator.pizza.GetPrice() + 4
}

