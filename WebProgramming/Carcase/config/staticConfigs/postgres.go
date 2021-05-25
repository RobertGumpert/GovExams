package staticConfigs

type PostgresConfigs struct {
	Username string `json:"username"`
	Password string `json:"password"`
	Port     string `json:"port"`
	DbName   string `json:"db_name"`
	Ssl      string `json:"ssl"`
}
