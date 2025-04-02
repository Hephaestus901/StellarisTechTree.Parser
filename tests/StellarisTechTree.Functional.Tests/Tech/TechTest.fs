module StellarisTechTree.Functional.Tests.Tech.TechTest

let Tech = """
tech_rift_sphere = {
    cost = @tier3cost2
    area = physics
    tier = 2
    category = { field_manipulation }
    is_rare = yes
    weight = 0

    feature_flags = {
        unlock_astral_rift_exploration
    }

    potential = {
        has_astral_planes_dlc = yes
    }
}
"""

let TrinaryComputing = """
tech_trinary_computing = {
    cost = @tier2cost3
    area = physics
    tier = 2
    category = { computing }
    ai_update_type = all
    is_insight = yes
    weight = 0

    potential = {
        has_first_contact_dlc = yes
    }

    modifier = {
        envoys_add = @insight_envoy_gain
        espionage_operation_speed_mult = 0.1
        espionage_operation_difficulty_add = -1
    }
}
"""

let NeuroQuantumLinks = """
tech_neuro_quantum_links = {
    area = physics
    tier = 3
    cost = @tier3cost1
    category = { computing }
    prerequisites = { "tech_basic_science_lab_2" "tech_integrated_cybernetics" }
    weight = @tier3weight1

    modifier = {
        planet_jobs_specialist_produces_mult = 0.05
    }

    potential = {
        OR = {
            is_machine_empire = no
            has_civic = civic_machine_assimilator
        }
    }

    weight_modifier = {
        factor = 1.5
        modifier = {
            factor = 0
            OR = {
                has_utopia = yes
                has_machine_age_dlc = yes
            }
            NOR = {
                has_ascension_perk = ap_the_flesh_is_weak
                has_ascension_perk = ap_organo_machine_interfacing
                has_ascension_perk = ap_organo_machine_interfacing_assimilator
            }
        }
        modifier = {
            factor = 0.25
            NOR = {
                has_trait_in_council = { TRAIT = leader_trait_expertise_computing }
                has_trait_in_council = { TRAIT = leader_trait_curator }
            }
        }
    }

    ai_weight = {

    }
}
"""

let LatheResonator = """
tech_lathe_resonator = {
    area = physics
    cost = 30000
    tier = 5
    category = { computing }
    ai_update_type = all
    is_rare = yes
    weight = @tier5weight1
    potential = {
        has_machine_age_dlc = yes
        has_ascension_perk = ap_cosmogenesis
        has_technology = tech_cosmogenesis_world
    }
    weight_modifier = {
        modifier = {
            factor = 0
            NOT = {
                any_owned_planet = {
                    is_planet_class = pc_cosmogenesis_world
                }
                has_ascension_perk = ap_cosmogenesis
            }
        }
        modifier = {
            factor = 2
            any_owned_planet = {
                is_planet_class = pc_cosmogenesis_world
                num_pops >= 50
            }
        }
        modifier = {
            factor = 2
            any_owned_planet = {
                is_planet_class = pc_cosmogenesis_world
                num_pops >= 100
            }
        }
    }
}
"""

let QuantumCatapult = """
tech_orbital_ring_tier_1 = {
    cost = @tier3cost2
    area = engineering
    category = { voidcraft }
    tier = 3
    weight = @tier3weight2
    prerequisites = { "tech_starbase_3" "tech_galactic_administration" "tech_planetary_infrastructure_1" }

    gateway = infrastructure

    potential = {
        has_overlord_dlc = yes
    }

    weight_modifier = {
        modifier = {
            factor = 0.1
            NOT = { years_passed > 50 }
        }
        modifier = {
            factor = 10
            any_neighbor_country = {
                has_technology = tech_orbital_ring_tier_1
            }
        }
        modifier = {
            factor = 2
            years_passed > 60
        }
        modifier = {
            factor = 3
            years_passed > 65
        }
        modifier = {
            factor = 4
            years_passed > 70
        }
        modifier = {
            factor = 5
            count_starbase_sizes = {
                starbase_size = starbase_starhold
                count >= 3
            }
        }
        modifier = {
            factor = 1.25
            has_tradition = tr_expansion_adopt
        }
        modifier = {
            factor = 1.25
            has_tradition = tr_expansion_finish
        }


    }

    prereqfor_desc = {
        ship = {
            title = "allow_orbital_rings"
            desc = "orbital_ring_tier_1_MEGASTRUCTURE_DETAILS"
        }
    }

    ai_weight = {
        factor = 1


    }
}
"""

let EcoSimulation = """
tech_eco_simulation = {
    weight_modifier = {
        modifier = {
            NOR = {
                has_country_flag = non_lithoid_subspecies
            }
        }
    }
}
"""

let ArcaneDeciphering = """tech_archaeoshield = {
    cost = @tier3cost3
    area = society
    category = { archaeostudies }
    tier = 3
    prerequisites = { "tech_archaeostudies" }
    is_rare = yes
    ai_update_type = all
    weight = @tier4weight3

    potential = {
        has_ancrel = yes
    }

    weight_modifier = {
        inline_script = {
            script = technologies/rare_technologies_weight_modifiers
            TECHNOLOGY = tech_archaeoshield
        }
        modifier = {
            factor = 0.1
            num_buildings = {  
                type = building_archaeostudies_faculty
                value < 1 
                disabled = no
                in_construction = no 
            }
        }
        modifier = {
            factor = 0.1
            NOT = {
                has_ascension_perk = ap_archaeoengineers
            }
        }
        modifier = {
            factor = 0
            has_ancrel = no
        }
        inline_script = "technology/archaeotech_weight"
    }
}"""

let techRiftSphere = """tech_rift_sphere = {
	cost = @tier3cost2
	area = physics
	tier = 2
	category = { field_manipulation }
	is_rare = yes
	weight = 0

	feature_flags = {
		unlock_astral_rift_exploration
	}

	potential = {
		has_astral_planes_dlc = yes
	}
}"""