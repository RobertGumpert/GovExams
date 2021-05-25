package pattern



// Общий интерфейс
type IPizza interface {
	GetPrice() int
}

// Базовый компонет #1
type BaseItalianPizza struct {}

func NewBaseItalianPizza() IPizza {
	return new(BaseItalianPizza)
}

func (component *BaseItalianPizza) GetPrice() int {
	return 10
}

// Базовый компонет #2
type BaseFrenchPizza struct {}

func NewBaseFrenchPizza() IPizza {
	return new(BaseFrenchPizza)
}

func (component *BaseFrenchPizza) GetPrice() int {
	return 15
}