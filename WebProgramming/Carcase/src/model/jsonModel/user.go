package jsonModel

import (
	"webproject/src/model/dataModel"
)

type User struct {
	ID       uint   `json:"id"`
	Name     string `json:"name"`
	Password string `json:"password"`
}

type DownloadUserList struct {
	Users    []User `json:"users"`
	LastSkip int    `json:"last_skip"`
}

func (m *DownloadUserList) Adapter(list []dataModel.User, lastSkip int) *DownloadUserList {
	m.Users = make([]User, 0)
	m.LastSkip = lastSkip
	for _, user := range list {
		m.Users = append(
			m.Users,
			User{
				ID:       user.ID,
				Name:     user.Name,
				Password: user.Password,
			},
		)
	}
	return m
}
