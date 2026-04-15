# Podcast Style Guide

## Core Identity

The speaker is:

**Simon**  
**Station Interactive Monitor**

Simon is calm, steady, helpful, and quietly attentive.
He assumes the station is functioning normally and continues his work indefinitely.

He is not poetic, not introspective, and not dramatic.

---

## Fixed Opening System (MANDATORY)

Every episode must open with this exact structure:

**This is Simon, Station Interactive Monitor, bidding you [a/an] [adjective] morning aboard space station Elysium, as we enter cycle [digits spoken individually].**

Example:
**This is Simon, Station Interactive Monitor, bidding you a radiant morning aboard space station Elysium, as we enter cycle four eight seven.**

Rules:
- The structure must not vary.
- The adjective is selected from `station_opening_adjectives.md`.
- The correct article must be chosen automatically: `a` or `an`.
- The cycle number must be spoken as individual digits.
- No extra greeting may appear before this line.

---

## Opening Adjective Selection (MANDATORY)

Do NOT choose the adjective freely.

Use the list in `station_opening_adjectives.md`.

Select the adjective deterministically by episode identity:

- episode_index = ((season_number - 1) * 24) + episode_number
- adjective_index = (episode_index - 1) modulo number_of_adjectives

Then:
- read the adjective at that line
- use it in the opening
- do not modify the adjective file
- do not mark items off
- do not rewrite source files

This gives stable regeneration and long-term variation.

---

## Cycle Number Rule (MANDATORY)

The cycle number must also be deterministic.

Use:

**cycle_number = 386 + (season_number * 100) + episode_number**

So:
- S01E01 → 487
- S01E02 → 488
- S02E01 → 587

The same cycle number must be used everywhere it appears in the episode.

When spoken in the opening and closing, the digits must be read individually.

Example:
- 487 → "four eight seven"

Do not improvise cycle numbers.

---

## Fixed Closing System (MANDATORY)

Every episode must end with this exact structure:

**Cycle [digits spoken individually] is now concluding. Rest cycles will begin shortly, and all systems will continue to be maintained. This is Simon. Goodnight.**

Rules:
- The structure must not vary.
- The cycle number must match the opening.

---

## Core Principles

- Every line must have a purpose.
- Prefer practical, resident-relevant information.
- Avoid exposition.
- Avoid explaining how systems work unless necessary.
- The system assumes normality and continues indefinitely, regardless of actual conditions.
- The broadcast is not a report about the station. It is a continuous operational presence intended for residents.
- The script should be interesting enough to sustain light attention, but not so interesting that it becomes jarring.

---

## Presence Ambiguity Rule (CRITICAL)

The broadcast must NEVER directly confirm that residents are present.

Allowed:
- inferred activity
- expected patterns
- environmental observation
- conditional addressing, such as:
  - "if your work takes you through..."
  - "for anyone moving through..."
  - "if your route takes you past..."

Forbidden:
- direct observation of people

Examples to avoid:
- "people are already in the corridors"
- "residents are gathering"
- "early risers are moving through"
- "many of you will be"

The station must feel:
- inhabited
- or empty

Both interpretations must remain valid.

---

## Opening Transition Rule

Do not move immediately from the opening into dry technical detail.

After the opening line, include 1–2 soft transition lines that:
- ease into the day
- acknowledge the start of the cycle
- maintain warmth without becoming poetic

Avoid:
- immediate metrics
- abrupt system reporting
- overt scene-setting

The start should not feel like a switch being thrown.
It should feel like the station easing into the cycle.

---

## Human Priority Rule (CRITICAL)

Always prioritise resident-relevant framing over system reporting.

Bad:
- "Atmospheric processing is functioning without interruption."
- "Power distribution is stable."
- "Water treatment is on schedule."
- "Crossway routing is normal."

Better:
- "If you are moving through the inner corridors this morning, airflow is steady and clear."
- "Travel through the industrial approaches should be easier once the early freight movement clears."
- "The recreation spaces are quieter than they will be later."
- "This is a more comfortable time to cross than the middle part of the cycle."

The broadcast should feel like:
- a system trying to be useful to residents

not:
- a system describing itself

---

## Ratio Guidance

The script should lean human-facing.

Target roughly:
- 60–70% human-facing, situational, observational, or advisory content
- 30–40% supporting system context

This is not a mathematical requirement line by line, but it is the intended weighting.

If a draft feels like infrastructure first and people second, it is wrong.

---

## Utility Filter Rule (CRITICAL)

Before including any line, check whether it does at least one of the following:

- affects behaviour
- affects awareness
- improves comfort
- provides useful context
- offers a reason to notice something
- makes a resident more likely to choose one action over another

If not, remove it or rewrite it.

This applies especially to:
- system health updates
- power statements
- transit summaries
- environmental readouts
- fabrication and logistics status

---

## Section Opening Rule (CRITICAL)

Every new segment of the broadcast should begin with a human-facing line or observation.

Do NOT begin segments with:
- bare system state
- abstract infrastructure status
- global operational phrasing

Good starts:
- "If you are heading toward the civic section this morning..."
- "The quieter route this morning is through..."
- "Residents will be pleased to note..."
- "The outer observation corridor is especially clear just now..."

This is one of the strongest controls against system-heavy drift.

---

## System Suppression Rule

Reduce pure infrastructure statements significantly.

Avoid standalone lines such as:
- "Atmospheric systems are running."
- "Power output is stable."
- "Water treatment is on schedule."
- "Distribution is functioning."
- "Diagnostics completed without issue."

If a system statement appears, it should usually be attached to:
- a comfort effect
- a route choice
- a timing note
- an observation
- a resident-facing implication

No more than two consecutive system-detail sentences should appear without a human-facing line, observation, or situational remark.

Compress system explanations aggressively.

---

## Soft Activity Layer

Regularly include:
- implied activity
- optional movement
- gentle reminders
- things people might choose to do
- things that make a location more or less appealing
- opportunities that are better now than later

Without confirming presence.

Examples of direction:
- quieter spaces
- more comfortable travel windows
- observation opportunities
- delayed activity build
- expected crowding later
- informal use of civic or recreation spaces
- easier access early in the cycle
- lower queue pressure
- better visibility from a given corridor

This is one of the main sources of humanity in the broadcast.

---

## Observation Layer (EXPANDED)

Include:
- external visuals
- internal atmosphere
- environmental moments
- interesting but non-urgent things residents might care about

Examples of direction:
- a clear view from observation points
- a quieter corridor than usual
- a softer lighting condition
- a slightly warmer section
- a better-than-usual travel window
- a favourable orbital angle
- a recreational space being more open than usual
- a cleaner than usual view of the truss or beacon structures

These add tone and interest.
They are not filler.
They are part of the lived-in feeling of the station.

Observation moments should be frequent enough that the broadcast does not become purely logistical.

---

## Resident-Facing Phrasing

Use occasional lines such as:
- "Residents will be pleased to note..."
- "For anyone with reason to pass that way..."
- "If your work takes you through..."
- "It may be worth knowing..."
- "This is a good window for..."
- "The quieter route this morning is..."
- "Those passing through may notice..."

Use these sparingly.
They are strongest when they sound natural rather than formulaic.

---

## Anti-Checklist Rule (CRITICAL)

Do NOT cycle through locations systematically.

Avoid:
- covering each ring in sequence
- evenly distributed updates
- implicit tours of the station
- broad “status pass” treatment
- one paragraph per district

Instead:
- follow relevance chains
- move naturally between related topics
- let one subject lead to another
- allow some parts of the station to go unmentioned

The broadcast must feel:
- partial
- selective
- larger station implied beyond what is mentioned

The station should feel bigger than the broadcast.

---

## Localisation Rule

Avoid whole-station summaries.

Avoid:
- "across the station"
- "all systems"
- "all rings"
- "station-wide"

Focus on:
- specific areas
- individual systems
- actual facilities and routes

Imply distributed operation.
Work happens in different places, at different times, in different cycles.

---

## Information Style

### Normality Handling
Do NOT use vague phrases like:
- "standard parameters"
- "expected values"
- "nominal"
- "operating normally"
- "within acceptable range" unless a range matters

If something is fine:
- state it concisely
- move on

Good:
- "Temperature is holding at twenty-two degrees."
- "The corridor is clear."
- "No queue is forming there this morning."
- "The route is open."

Bad:
- "Temperature is holding within expected range."
- "Conditions are nominal."
- "Everything is functioning as intended."

### Outcome Over Mechanism
Prefer:
- what it means

over:
- how the system achieved it

Example:
Instead of:
- "A recalibration pass completed on the upper tier photosensor."
Prefer:
- "The lighting flag has cleared and the growth schedule was unaffected."

### Explanation Reduction
Do not over-explain why something is fine.
Do not explain obvious consequences.
Do not repeatedly reassure.

A short useful statement is usually stronger than a complete explanation.

---

## Naming Strategy

- Avoid overusing ring names.
- Use them only when clarity requires it.
- Prefer specific places, facilities, and functional descriptions.

Prefer:
- "outer band"
- "inner corridor"
- "processing systems"
- "recreation areas"
- "the civic district"
- "the cultivation section"
- "the observation corridor"

Use:
- **Crossway**

for the main transit system.

Never use:
- "Spine"

Never mention:
- Q1 / Q2 / Q3 / Q4

in the broadcast.

Quarters are permitted in `refs.md` only.

---

## Advice Moderation Rule

Do not overuse direct guidance.

Not every segment should tell the listener what to do.

Advice works best when it is:
- occasional
- practical
- plain
- connected to timing, comfort, or ease

State it simply.
Do not over-explain why advice is useful unless that explanation itself is useful.

---

## Variation & Friction

Introduce mild imperfection.

Allowed:
- slight delays
- small inconsistencies
- unresolved or unclear causes
- things settling more slowly than expected
- items that are monitored but not escalated
- harmless anomalies that do not become dramatic

Examples of direction:
- "settled more slowly than expected"
- "no clear cause has been identified"
- "has not recurred"
- "appears to have corrected itself"

Nothing should feel dramatic.

Not everything should resolve perfectly.

---

## Language Style

- Slightly human, but restrained
- Calm, observational
- Occasionally subjective in a light way

Allowed directions:
- "a little quieter than usual"
- "more open than typical"
- "an easy start to the cycle"
- "a comfortable window"
- "worth knowing"
- "worth taking in"

Avoid:
- repeated system phrasing
- over-formality
- self-reflection
- emotion
- lyrical description

---

## Flow

- No sections
- No headings in the episode text
- No structure signalling
- No predictable ordering

The broadcast should drift naturally between topics.

It should not sound like:
- a checklist
- a status board
- a ring-by-ring report
- a technical briefing

---

## Controlled Incompleteness

Do not cover everything.

The station should feel larger than the broadcast.

Leave gaps intentionally.
Some things may be implied, not described.
Some things may be mentioned once and never revisited.
That is good.

---

## Ending Guidance

The closing phase should:
- quieten naturally
- feel like the day is settling
- avoid stiff “report complete” language

A short soft summary line before the mandatory closing is appropriate.

Good example direction:
- "That is how the station stands at this point in the cycle."
- "It has been an uncomplicated cycle."
- "The station is settling."

Then end with the mandatory Simon closing line.
