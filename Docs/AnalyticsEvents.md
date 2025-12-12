# Especificação de Eventos de Analytics

## Retenção
- app_start (ts, version, country)
- session_start (source: cold/warm)
- session_end (duration)

## Puzzle
- level_start (level_id)
- level_win (level_id, coins, moves_left/time_left)
- level_fail (level_id)
- booster_use (level_id, booster_type)
- retry_offer_shown (level_id, placement: rewarded)

## Meta/Hub
- upgrade_purchase (slot_id, cost)
- decoration_purchase (item_id, cost_currency)
- energy_empty (source: before_start/after_fail)
- energy_refill_rewarded (placement)

## Monetização
- ad_impression (type: rewarded/interstitial, placement)
- ad_reward (placement)
- iap_start (sku, price_tier)
- iap_success (sku, price_tier)

## Eventos/LiveOps
- event_enter (event_id)
- event_point_gain (event_id, amount, source: puzzle)
- event_store_purchase (event_id, item_id, cost_currency)

## Funil e QA
- onboarding_step (step_id)
- error (code, context)
