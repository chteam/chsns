<!--
Sync Impact Report:
Version Change: Initial → 1.0.0
Modified Principles: None (initial creation)
Added Sections:
  - Core Principles (5 principles defined)
  - Technology Stack Standards
  - Development Workflow
  - Governance
Templates Status:
  ✅ plan-template.md - reviewed and aligned
  ✅ spec-template.md - reviewed and aligned
  ✅ tasks-template.md - reviewed and aligned
  ✅ All command prompts - reviewed for generic guidance
Follow-up TODOs: None
-->

# CHSNS Constitution

## Core Principles

### I. Component-Based Architecture

All new features MUST be developed as modular, reusable components with clear boundaries:
- Frontend components (Vue 3 + Ant Design Vue) MUST be self-contained with props/emits contracts
- Backend services (.NET 10) MUST follow service-oriented architecture with dependency injection
- Each component/service MUST have a single, well-defined responsibility
- Components MUST be independently testable without requiring full application context
- Legacy code in `Src/` folder is exempt but SHOULD be refactored when touched

**Rationale**: Modular architecture enables parallel development, easier testing, maintainability, and gradual migration from legacy codebase.

### II. API-First Development

All frontend-backend communication MUST go through well-defined REST APIs:
- API contracts MUST be documented before implementation begins
- Use JSON for request/response payloads with consistent structure
- RESTful conventions MUST be followed (GET/POST/PUT/DELETE, proper status codes)
- API versioning MUST be implemented for breaking changes (e.g., `/api/v1/`, `/api/v2/`)
- OpenAPI/Swagger documentation MUST be maintained for all endpoints

**Rationale**: Clear API contracts enable independent frontend/backend development, easier testing, and prevent integration issues.

### III. Test-Driven Development (NON-NEGOTIABLE)

TDD cycle MUST be followed for all new code:
1. Write test cases based on acceptance criteria
2. Get user/stakeholder approval on test scenarios
3. Verify tests fail (RED phase)
4. Implement minimal code to pass tests (GREEN phase)
5. Refactor while keeping tests green (REFACTOR phase)

Tests are MANDATORY for:
- All new API endpoints (contract tests)
- Business logic and service layer (unit tests)
- Critical user journeys (integration tests)
- Vue components with complex logic (component tests)

**Rationale**: TDD ensures code correctness, prevents regressions, serves as living documentation, and builds confidence in refactoring legacy code.

### IV. Progressive Migration Strategy

Legacy code migration MUST follow these rules:
- Do NOT attempt big-bang rewrites
- When fixing bugs or adding features to legacy code, refactor that specific area
- New features MUST be built in `frontend/` and `backend/` directories using modern stack
- Legacy `Src/` code is read-only unless actively being migrated
- Document migration progress and maintain backward compatibility during transition
- Each migration increment MUST be independently deployable

**Rationale**: Gradual migration reduces risk, maintains business continuity, and allows learning from each increment.

### V. Observability and Maintainability

All code MUST support operational visibility and long-term maintenance:
- Structured logging MUST be used (with correlation IDs for request tracing)
- Error messages MUST be actionable and include context
- Performance-critical paths MUST be instrumented (e.g., API response times)
- Code MUST be documented: complex logic gets inline comments, public APIs get XML/JSDoc comments
- Configuration MUST be externalized (environment variables, config files)
- Follow consistent naming conventions: C# (PascalCase for public, camelCase for private), Vue (kebab-case for components, camelCase for methods)

**Rationale**: Observable systems are debuggable in production; maintainable code reduces long-term costs and enables team scalability.

## Technology Stack Standards

### Frontend Requirements

- **Framework**: Vue 3 with Composition API (`<script setup>` syntax preferred)
- **UI Library**: Ant Design Vue 4.x (latest stable)
- **State Management**: Pinia (for complex state), provide/inject (for simple cases)
- **Build Tool**: Vite (for fast development and optimized builds)
- **Testing**: Vitest (unit/component tests), Playwright (E2E tests)
- **Type Safety**: TypeScript MUST be used for all new code
- **Code Quality**: ESLint + Prettier with project-standard configs

### Backend Requirements

- **Framework**: .NET 10 (ASP.NET Core for web APIs)
- **API Style**: RESTful with JSON payloads
- **Database**: Entity Framework Core for data access
- **Authentication**: JWT-based authentication with proper token management
- **Testing**: xUnit or NUnit for unit tests, integration test projects for API tests
- **Code Quality**: .editorconfig for consistent formatting, analyzers for code quality
- **Logging**: Structured logging with Serilog or Microsoft.Extensions.Logging

### Development Environment

- **Version Control**: Git with conventional commit messages
- **Branching**: Feature branches from `main`, PR-based workflow
- **CI/CD**: Automated builds and tests on pull requests
- **Documentation**: Markdown files in `docs/` directory, inline code comments

## Development Workflow

### Feature Development Process

1. **Specification Phase** (`/speckit.specify`):
   - Document user stories with acceptance criteria
   - Prioritize stories (P1, P2, P3)
   - Define API contracts if backend changes needed
   - Get stakeholder approval

2. **Planning Phase** (`/speckit.plan`):
   - Research technical approaches
   - Define data models and component structure
   - Create implementation plan with tasks
   - Review constitution compliance

3. **Implementation Phase** (`/speckit.tasks`):
   - Write tests first (TDD)
   - Implement in small, reviewable increments
   - Update documentation alongside code
   - Run tests continuously during development

4. **Review Phase**:
   - Code review checks: functionality, tests, constitution compliance
   - All tests MUST pass before merge
   - Documentation MUST be complete
   - Legacy code touched MUST be improved (not degraded)

### Quality Gates

Before merging to `main`:
- ✅ All automated tests pass
- ✅ Code review approved by at least one team member
- ✅ API documentation updated (if applicable)
- ✅ No new linting/formatting violations introduced
- ✅ Constitution principles verified

### Priority of Work

1. **P1 (Critical)**: Security fixes, data loss bugs, production outages
2. **P2 (High)**: User-facing bugs, essential features, technical debt blocking new work
3. **P3 (Normal)**: Feature enhancements, non-blocking improvements, refactoring
4. **P4 (Low)**: Nice-to-haves, optimizations, exploratory work

## Governance

### Authority and Compliance

- This constitution supersedes all other development practices and conventions
- All pull requests MUST be reviewed for constitution compliance
- Deviations from principles MUST be explicitly justified in PR descriptions
- Constitution violations without justification MUST be rejected

### Amendment Process

Constitution changes require:
1. Written proposal explaining rationale for change
2. Impact analysis on existing code and workflows
3. Team discussion and consensus
4. Version bump following semantic versioning:
   - **MAJOR**: Backward-incompatible principle changes or removals
   - **MINOR**: New principles added or material expansions
   - **PATCH**: Clarifications, wording improvements, non-semantic changes
5. Migration plan for affected code (if applicable)
6. Update of all dependent templates and documentation

### Complexity Justification

Any code or architecture that increases complexity MUST be justified by:
- Clear business value or technical necessity
- Documented alternatives considered and rejected
- Plan for maintaining the complexity over time
- Agreement that benefit outweighs maintenance cost

### Runtime Guidance

For day-to-day development guidance and AI agent instructions, refer to:
- `.specify/templates/` for command workflows
- `.github/prompts/speckit.*.prompt.md` for agent-specific instructions
- `docs/` directory for architecture decision records and guides

**Version**: 1.0.0 | **Ratified**: 2025-11-13 | **Last Amended**: 2025-11-13
