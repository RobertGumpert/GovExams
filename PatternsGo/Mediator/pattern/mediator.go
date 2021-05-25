package pattern

type IMediator interface {
	canArrive(ITrain) bool
	notifyAboutDeparture()
}
