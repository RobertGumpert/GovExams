package jsonModel

type CreateUser struct {
	ID uint `json:"id"`
	Name string `json:"name"`
	Password string `json:"password"`
}
