package model

import (
	"gorm.io/gorm"
)

type UserDataModel struct {
	gorm.Model
	Name     string `gorm:"not null;"`
	Password string `gorm:"not null;"`
	Articles []ArticleDataModel `gorm:"foreignKey:UserID; constraint:OnDelete:CASCADE;"`
}


