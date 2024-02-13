import { Profile } from "./Account.js"


export class Cult{
  constructor(data){
    this.id = data.id
    this.name = data.name
    this.coverImg = data.coverImg
    this.bio = data.bio
    this.leaderId = data.leaderId
    this.leader = new Profile(data.leader)
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}

export class CultViewModel extends Cult{
  constructor(data){
    super(data)
    this.cultMemberId = data.cultMemberId
  }
}
