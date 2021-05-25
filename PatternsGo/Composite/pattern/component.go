package pattern

// Общий интерфейс
type IFileSystem interface {
	Search(name string) bool
}

// Сущность
type file struct {
	name string
}

func CreateFile(name string) IFileSystem {
	return &file{name: name}
}

func (entity *file) Search(name string) bool {
	if entity.name == name {
		return true
	}
	return false
}

// Компоновщик
type directory struct {
	files []IFileSystem
	name  string
}

func CreateDirectory(name string, files ...IFileSystem) IFileSystem {
	return &directory{files: files, name: name}
}

func (composite *directory) Search(name string) bool {
	for _, f := range composite.files {
		if f.Search(name) {
			return true
		}
	}
	return false
}
