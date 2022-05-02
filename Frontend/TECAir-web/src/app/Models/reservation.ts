export class Reservation {
    id:number=0
    expiration_date: Date = new Date()
    date_of_issue : Date = new Date()
    check: boolean = false
    id_flight: number | undefined
    id_user: number | undefined
}
