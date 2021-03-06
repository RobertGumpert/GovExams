package dataModel

import (
	"gorm.io/gorm"
)

type User struct {
	gorm.Model
	Name     string    `gorm:"not null;"`
	Password string    `gorm:"not null;"`
	Articles []Article `gorm:"foreignKey:UserID; constraint:OnDelete:CASCADE;"`
}


