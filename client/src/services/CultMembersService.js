
import {api} from './AxiosService.js'
import {logger} from '../utils/Logger.js'
import { CultMemberProfile } from '../models/Account.js'
import { AppState } from '../AppState.js'
import { CultViewModel } from '../models/Cult.js'

class CultMembersService{
async getCultMembers(cultId){
  const response = await api.get(`api/cults/${cultId}/cultMembers`)
  logger.log('🧌🧌', response.data)
  const cultists = response.data.map(cultMemberProfile => new CultMemberProfile(cultMemberProfile))
  AppState.activeCultMembers = cultists
}

async joinCult(cultMemberData){
  const response = await api.post('api/cultMembers', cultMemberData)
  logger.log('🧌✨', response.data)
  const cultist = new CultMemberProfile(response.data)
  AppState.activeCultMembers.push(cultist)
}

async getMyCults(){
  const response = await api.get('account/cultMembers')
  logger.log('👥🔒', response.data)
  const myCults = response.data.map(cultVM => new CultViewModel(cultVM))
  AppState.accountCults = myCults
}
}

export const cultMembersService = new CultMembersService()
