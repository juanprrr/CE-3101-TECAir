export class User {
    id:number = 0
    name:string = ""
    first_lastname:string = ""
    second_lastname:string = ""
    phone:number | undefined
    email:string | undefined
    student_id:number | undefined
    id_university:number | undefined
    password:string | undefined

    getFullName(){
        var fullname = this.name + " " + this.first_lastname + " " + this.second_lastname
        return fullname
    }
}
