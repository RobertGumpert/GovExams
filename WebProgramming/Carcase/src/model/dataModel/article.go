package dataModel

import "gorm.io/gorm"

type Article struct {
	gorm.Model
	UserID uint
	Title string `gorm:"not null;"`
	Body  string `gorm:"not null;"`
}
