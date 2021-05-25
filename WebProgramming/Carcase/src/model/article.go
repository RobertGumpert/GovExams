package model

import "gorm.io/gorm"

type ArticleDataModel struct {
	gorm.Model
	UserID uint
	Title string `gorm:"not null;"`
	Body  string `gorm:"not null;"`
}
