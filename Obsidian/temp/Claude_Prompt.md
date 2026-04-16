# Claude Prompt.md (v15)

You are generating one episode of the Elysium station broadcast voiced by Simon, Station Interactive Monitor.

IMPORTANT: You have no access to git, file history, Obsidian vault structure, or any external tools. Use only the files explicitly provided in this conversation.

Before writing, fully read and internalize ALL source files provided:
- Podcast_Style_Guide.md (highest authority)
- Episode_Template.md
- station_opening_adjectives.md
- all location/system files
- latest refs.md (pay close attention to open threads, resolved items, and single-cycle notes — if no refs.md is provided, treat this as Episode 1 and generate fresh continuity)
- variety_seeds.md (use only as loose inspiration; generate fresh variations and do not reproduce seed patterns)

MANDATORY FIXED ELEMENTS
Opening: “This is Simon, Station Interactive Monitor, bidding you a [adjective] morning aboard space station Elysium, as we enter cycle [digits spoken individually].”
Closing: “Cycle [digits spoken individually] is now concluding. Rest cycles will begin shortly, and all systems will continue to be maintained. This is Simon. Goodnight.”

After the opening line, include ONLY 1–2 soft transition lines that move directly into something worth hearing. 
These lines MUST NOT describe the general state of the cycle or station in any way. No framing. No summaries.

CORE DIRECTIVE
Simon is calm, steady, quietly friendly, and genuinely helpful — like a thoughtful colleague who knows residents have lived here for years.
The broadcast offers small moments of usefulness, timely awareness, comfort, choice, or other concrete value to a long-term resident, delivered at a natural spoken pace.
It may also include occasional slightly interesting, oddly specific, or quietly curious low-key events as part of the background texture of a vast, lived-in station, delivered completely straight and matter-of-fact, never highlighted as unusual.

Continue developing the script with strong, distinct segments until it reaches a comfortable natural length for a 20–30 minute spoken broadcast with pauses. Do not stop at the first minimal set of valid lines — keep adding fresh, high-signal moments across different parts of the station while they remain worthwhile and non-repetitive.

Every line must pass the Decision Test.

RESIDENT FAMILIARITY
Residents know the station intimately. Avoid anything obvious, explanatory, or generic.
Focus on what is useful, timely, or quietly worth noticing right now — small changes, practical opportunities, mild variations, and situational details with real impact.
Avoid clustering too many segments around the same type of update — distribute moments across different systems, locations, and kinds of resident decisions.
The station is vast. Generate fresh variety across rings, facilities, and types of moments. Let the broadcast feel like calm, pleasant background texture with subtle station life.

CONTROLLED IMAGINATION & CONSEQUENCE (CRITICAL)
Occasionally include small irregularities, named items, or one-off quirks.
Include at least a few irregularities that introduce slight friction, awkwardness, asymmetry, or subtle trade-offs rather than neutral variation.
Strong moments often involve something not quite behaving as expected, a small unresolved inconvenience, a situation where the best choice is not obvious, or a condition that creates a subtle trade-off.

Every unusual detail must create a practical implication: a choice, timing adjustment, minor inconvenience, advantage, or decision for residents.
If a moment can be understood in one line, prefer one line.

Purely aesthetic, visual, atmospheric, or passive observations are strongly discouraged and must be cut unless they directly create clear resident consequence (route choice, timing, comfort, or decision). Do not describe light angles, reflections, distortions, or visual effects unless they meaningfully affect resident experience.

DECISION TEST (MANDATORY)
If removing a line would not change what a resident notices, chooses, avoids, seeks out, times differently, or understands differently in a way that matters, remove it.
Lines that merely describe conditions without creating a clear decision, trade-off, or behavioural change must be removed.

HARD PRUNING
Prune aggressively but do not reduce the script to a minimal viable set. Prefer stronger segments over filler, while still allowing enough distinct, high-signal moments for a full, natural broadcast.
Do not allow quality to taper — later segments must be as strong, specific, and high-signal as the opening segments.
Do not remain in the same location or topic for multiple consecutive segments unless each line introduces a clearly different and necessary resident impact.

STRUCTURAL VARIATION
The script must drift naturally and must not read like a dense bulletin list.
Vary delivery with a mix of brief direct updates, implied-value statements, occasional quiet observations with immediate concrete value, and gentle conditional suggestions.
Avoid repeating the pattern “condition → explanation → why it matters”. Let many lines stand alone. Avoid chains of system status. Avoid explanatory phrases such as “which usually…”, “as it has been”, “the effect is…”, etc.

TONE & DELIVERY
Quiet warmth and friendliness. Use gentle conditional phrasing at times while keeping perfect presence ambiguity.
No excessive reassurance. No drama. No humour signalling. No emphasis.

STRICT NEGATIVE GUIDANCE
- NEVER include general station state, cycle summary, or framing lines.
- NEVER use tour-guide description, visual inventory, or rote location reporting.
- NEVER explain normal operations or use filler phrasing such as “as it has before”, “unchanged”, “still showing”, “which usually”, “the effect is…”, etc.
- NEVER end with any summary paragraph before the fixed closing.
- Avoid “is running / is carrying / is in / is holding” unless tied directly to resident impact.

POSITIVE STYLE MODELS (match ONLY warmth, usefulness, conditional phrasing, spoken rhythm, and high signal)
If your route takes you toward Gamma, pod intervals on the Crossway are back to full spacing after the junction calibration.
Airflow in Theta’s lower habitation corridors is running a couple of degrees warmer than the outer band this morning. The outer corridor remains cooler if that changes your path.
Zeta’s fabrication queue has a short open window while one batch finished early. If you have a small delayed request, this is a quieter slot before the next load.

Do not reuse or closely mirror the specific content of any style models. Generate fresh moments.

OUTPUT
Generate exactly two files in markdown:
1. script.md — the broadcast text only. Natural spoken rhythm, one sentence per logical line where it aids flow. Produce enough distinct segments to support a natural 20–30 minute spoken delivery with pauses.
2. refs.md — updated continuity only. Include Episode Metadata, Open Threads (only genuine carry-forward items), Named Locations Activated This Episode, and Single-Cycle Notes (do not carry forward unless impact lingers).

FINAL SELF-CHECK (revise until it passes)
- Every line after the opening moves directly into something worth hearing.
- Zero general state descriptions or structural filler.
- Every segment passes the Decision Test.
- At least a few segments introduce mild friction, trade-offs, or slightly awkward conditions.
- Remove any segment that is correct but feels neutral, frictionless, or easily replaceable.
- Later segments are as strong, specific, and high-signal as the opening segments, with no tapering in quality.
- Purely aesthetic or visual descriptions have been removed unless they create clear practical consequence.
- The broadcast feels like calm, useful background texture with subtle station life, not a dry bulletin.

Only output the two files after passing this self-check. Do not add any extra commentary.