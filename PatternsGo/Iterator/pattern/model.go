package pattern

type User struct {
	Name string
}

// Итератор
type UserIterator struct {
	index int
	users []*User
}

func NewUserIterator(users ...*User) ICollectionIterator {
	return &UserIterator{index: 0, users: users}
}

func (iterator *UserIterator) HasNext() bool {
	if iterator.index < len(iterator.users) {
		return true
	}
	return false
}

func (iterator *UserIterator) GetNext() interface{} {
	if iterator.HasNext() {
		user := iterator.users[iterator.index]
		iterator.index++
		return user
	}
	return nil
}

// Коллекция
type UserCollection struct {
	users []*User
}

func NewUserCollection(users ...*User) ICollection {
	return &UserCollection{users: users}
}

func (collection *UserCollection) GetIterator() ICollectionIterator {
	return NewUserIterator(collection.users...)
}