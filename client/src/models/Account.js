
export class Profile{
  constructor(data){
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
  }
}

export class Account extends Profile {
  constructor(data) {
    super(data) // invokes the contractor from the extend class
    // this.id = data.id
    this.email = data.email
    this.phoneNumber = data.phoneNumber
    this.creditCardNumber = data.creditCardNumber
    // this.name = data.name
    // this.picture = data.picture
    // TODO add additional properties if needed
  }
}
