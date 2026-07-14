# ICINCO Research Reframe

## Best Scientific Positioning

Treat the study as a pilot evaluation of an **instrumented immersive digital-twin training platform** for smart-factory procedural learning. This is stronger than presenting it as a simple VR satisfaction study. ICINCO reviewers are likely to care about relevance, originality, technical quality, significance, experimental results, critical discussion, and whether figures/conclusions are convincing; the pasted reviewer text makes those criteria explicit.

## Proposed Research Question

**Can an instrumented standalone VR training scenario for a smart-factory labeling workstation produce measurable behavioral evidence of procedural learning while remaining acceptable and comfortable for users?**

## New Hypotheses

- **H1 Procedural efficiency improves with repeated VR exposure.** Measurable learning/familiarization effect in a randomized within-subject VR procedural task.
- **H2 Interaction errors decrease as users stabilize motor/procedural control.** Error data are promising but should be framed as secondary pilot evidence.
- **H3 The platform is feasible for immersive industrial training.** Usability/comfort feasibility is one of the strongest submission claims.
- **H4 Stress-event condition produces measurable objective burden without unacceptable discomfort.** Treat as an exploratory manipulation requiring stronger event logs in future work.
- **H5 Presence/realism predicts performance accuracy.** Do not make this a central ICINCO claim; mention ceiling effects.

## What the Data Can Prove Now

- **Procedural efficiency is the strongest result.** Total time changed from Run 1 101.1 +/- 41.1s to Run 2 65.6 +/- 31.0s and Run 3 67.5 +/- 34.5s. Friedman p=0.002, Kendall W=0.53.
- **Error reduction is useful but secondary.** False grabs changed from 5.7 +/- 7.4 to 3.0 +/- 2.1 and 2.2 +/- 1.8. Omnibus p=0.360; no pairwise contrast is statistically significant.
- **Feasibility is strong.** Acceptance is above 4/5 (p=<0.001), presence/realism is above 5/7 (p=<0.001), and symptoms are below 1/3 (p=<0.001). This is a clean ICINCO-friendly claim.
- **Stress/randomized-condition effects are not proven.** Stress is descriptively slower (83.2s vs Guided 72.4s) and more error-prone (5.3 vs Guided 2.9), but condition tests are not significant in n=12.

## Recommended ICINCO Paper Angle

Use a title like: **Instrumented Immersive Training within a Smart-Factory Digital-Twin Project: A Pilot Evaluation of a VR Labeling Workstation**.

### Draft Abstract Logic

This paper presents an instrumented immersive VR training scenario for a smart-factory labeling workstation. The system reproduces a procedural industrial task in Unity/Meta Quest and logs objective performance indicators, including completion time, step-level timing, and false-grab errors. A randomized within-subject pilot study with 12 participants evaluated three scene conditions and repeated exposure to the task, complemented by subjective measures of workload, presence, comfort, and acceptance. Results show a significant reduction in completion time across chronological runs, high acceptance and presence, and low VR symptoms. Error reduction and stress-condition effects are promising but not definitive in the current sample. The study contributes a measurement-capable immersive training platform and a pilot evaluation framework for future digital-twin training research in smart factories.

The paper should be organized around four contributions:
- A standalone Meta Quest / Unity VR scenario reproducing a smart-factory labeling workstation.
- Automated objective logging of total time, step time, and interaction errors.
- A randomized within-subject pilot protocol combining objective behavior and subjective experience measures.
- Evidence that the platform is measurable, acceptable, comfortable, and sensitive to learning across exposure.

## Suggested Paper Structure

1. **Introduction:** problem of industrial procedural training, need for repeatable and measurable VR training, paper contributions.
2. **Related Work:** VR for industrial training, digital twins in smart factories, procedural learning and guided-to-autonomous training.
3. **System Design:** Unity architecture, Meta Quest deployment, labeling task, guidance/stress variants, data logging.
4. **Experimental Protocol:** participants, randomized condition order, objective metrics, questionnaire composites, analysis plan.
5. **Results:** learning curve first, errors second, feasibility thresholds third, condition effects and correlations as exploratory.
6. **Discussion:** what the pilot proves, what remains underpowered, why the data pipeline matters, how to improve the next study.
7. **Conclusion:** emphasize instrumented platform + pilot evidence, not definitive superiority of one condition.

## Reviewer-Risk Handling

- **Needs more experimental results:** answer by being transparent that this is a pilot and by showing objective + subjective endpoints, not only questionnaire results.
- **Needs comparative evaluation:** compare conditions within-subject, but admit condition effects are not confirmed; propose a future baseline against video/SOP/manual training.
- **Improve critical discussion:** explicitly discuss n=12, realized order imbalance, five step-time integrity flags, ceiling effects, and missing event-severity logging.
- **Figures are adequate:** use the generated figures with mean, SD/CI, p-values, effect sizes, and conservative interpretation.

## Claims to Avoid or Keep Exploratory

- Do not claim that the stress condition was statistically proven to degrade performance.
- Do not claim that presence predicts accuracy; your current data do not support it.
- Do not overstate error reduction as a confirmed omnibus effect.
- Do not present this as a definitive efficacy trial; present it as a rigorous pilot with a credible next-study plan.

## Figure Set

- [Reframed study model](fig1_reframed_study_model.png)
- [Primary learning endpoint with p-values and 95% CI](fig2_primary_learning_time.png)
- [Secondary error endpoint](fig3_error_learning.png)
- [Randomized condition effects](fig4_randomized_condition_effects.png)
- [Subjective feasibility thresholds](fig5_subjective_feasibility_thresholds.png)
- [Evidence map for ICINCO claims](fig6_icinco_evidence_map.png)
