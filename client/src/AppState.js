import { reactive } from 'vue'
import { Cult, CultViewModel } from './models/Cult.js'
import { CultMemberProfile } from './models/Account.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

/** @type {CultViewModel[]} */
  accountCults: [],


  /** @type {Cult[]} */
  cults: [],
  /** @type {Cult} */
  activeCult: null,
/** @type {CultMemberProfile[]} */
  activeCultMembers: []
})
