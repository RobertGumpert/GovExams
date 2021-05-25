package pattern

type ICollectionIterator interface {
	HasNext() bool
	GetNext() interface{}
}

type ICollection interface {
	GetIterator() ICollectionIterator
}





